using CThub.Domain.Abstractions;
using CThub.Infrastructure.Extensions;
using CThub.Infrastructure.Hubs;
using CThub.Infrastructure.RealTime;
using Microsoft.AspNetCore.Identity;

namespace CThub.Api;

public static class DependencyInjection
{
    public static IServiceCollection AppApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddSwaggerGen();
        services.AddControllers();
        // services.AddSqlServer<>()
        // services.AddIdentity<>()

        services.AddCors(opt =>
        {
            opt.AddPolicy("AllowAll", build =>
            {
                build.AllowAnyOrigin();
                build.AllowAnyHeader();
                build.AllowAnyMethod();
            });
        });
        // services.AddSignalR();
        return services;
    }


    public static WebApplication UseApiServices(this WebApplication app)
    {

        app.UseExceptionHandler("/error");
        // if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.MapHub<NotificationHubClient>("/notification-hub");
        app.UseHttpsRedirection();
        app.MapControllers();
        app.UseCors("AllowAll");
        return app;
    }
 }