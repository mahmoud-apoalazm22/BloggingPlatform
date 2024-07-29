using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Domain.Common.Interfaces;
using BloggingPlatform.Infrastructure.Authentication.PasswordHasher;
using BloggingPlatform.Infrastructure.Authentication.TokenGenerator;
using BloggingPlatform.Infrastructure.BlogPosts;
using BloggingPlatform.Infrastructure.Comments;
using BloggingPlatform.Infrastructure.Common.Persistence;
using BloggingPlatform.Infrastructure.Followers;
using BloggingPlatform.Infrastructure.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BloggingPlatform.Infrastructure;
public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(configuration)
                .AddPersistence(configuration);
        return services;
    }
     
    public static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<BloggingPlatformtDbContext>(Options =>
        {
            Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IFollowerRepository, FollowerRepository>();
        services.AddScoped<IBlogPostRepository, BlogPostRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => 
        serviceProvider.GetRequiredService<BloggingPlatformtDbContext>());
        return services;
    }
    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.Section, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            });

        return services;
    }
}
