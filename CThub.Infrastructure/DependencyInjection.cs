using CThub.Application.Authentication.Repository;
using CThub.Application.Common.Authentication;
using CThub.Application.DriverQueueImpl.Repository;
using CThub.Application.Hubs;
using CThub.Application.Notification;
using CThub.Application.Ride.Repository;
using CThub.Application.Scheduler.Repository;
using CThub.Application.Stop.Repository;
using CThub.Domain.Abstractions;
using CThub.Domain.Models;
using CThub.Infrastructure.Authentication;
using CThub.Infrastructure.Data;
using CThub.Infrastructure.Hubs;
using CThub.Infrastructure.Interceptors;
using CThub.Infrastructure.Notification;
using CThub.Infrastructure.Persistence;
using CThub.Infrastructure.Persistence.Cache;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CThub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, ConfigurationManager configuration)
    {
        //register service to conatiner
        service.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptors>();
        service.AddScoped<ISaveChangesInterceptor, DispatchDomainEventInterceptor>();
        
        service.AddDbContext<ApplicationDbContext>((sp, option) =>
            option.UseSqlServer(configuration.GetConnectionString("Database")));
        service.AddDbContext<AppDbContext>((sp, opt)  =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Database"));
            opt.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });
        
        Console.WriteLine(configuration.GetConnectionString("Redis") + "connction string");

        service.AddHttpClient();
        service.Configure<JwtSetting>(configuration.GetSection(JwtSetting.SectionName));
        service.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();      
        service.AddSingleton<INotificationHubServer, NotificationHubClient>();
        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<IPrevStopRepository, PrevStopRepository>();
        service.AddScoped<INextStopRepository, NextStopRepository>();
        service.AddScoped<IStopRepository, StopRepository>();
        service.AddScoped<IRideRepository, RideRepository>();
        service.AddScoped<IScheduleRepository, ScheduleRepository>();
        service.AddScoped<IDriverQueueRepository, DriverQueueRepository>();
        service.AddScoped<IDriverRepository, DriverRepository>();
        service.AddScoped<IFCMMessaging, FCMesaging>();
        service.AddStackExchangeRedisCache(opt =>
        {
            string conn = configuration.GetConnectionString("Redis")!;
            opt.Configuration = conn;
        });
        service.AddMemoryCache();
        // service.Decorate<IStopRepository, CachedStopRepository>();
        
        
        service.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        return service;
    }
}