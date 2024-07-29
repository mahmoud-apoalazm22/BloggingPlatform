using BloggingPlatform.Api;
using BloggingPlatform.Application;
using BloggingPlatform.Infrastructure;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, config) => config
            .ReadFrom.Configuration(context.Configuration));

builder.Services.AddPresentation()
                .AddApplication()
                .AddInfrastructure(builder.Configuration);




WebApplication app = builder.Build();


    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();



    app.Run();



