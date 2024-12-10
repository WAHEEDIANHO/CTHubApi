using CThub.Domain.Abstractions;
using CThub.Infrastructure.Extensions;
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
        return services;
    }


    public static WebApplication UseApiServices(this WebApplication app)
    {

        app.UseExceptionHandler("/error");
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.MapControllers();
        return app;
    }
 }