using BloggingPlatform.Api.Services;
using BloggingPlatform.Application.Common.Interfaces;

namespace BloggingPlatform.Api;

public static  class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddProblemDetails();
        services.AddHttpContextAccessor();
        services.AddAuthentication();
        services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();

        return services;
    }
}
