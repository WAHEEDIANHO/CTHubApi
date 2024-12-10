using CThub.Application.Common.Authentication;
using CThub.Application.Common.Persistence.Authentication;
using CThub.Domain.Abstractions;
using CThub.Domain.Models;
using CThub.Infrastructure.Authentication;
using CThub.Infrastructure.Data;
using CThub.Infrastructure.Interceptors;
using CThub.Infrastructure.Persistence;
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
        service.AddDbContext<UserDbContext>((sp, opt)  =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Database"));
            opt.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });
        service.Configure<JwtSetting>(configuration.GetSection(JwtSetting.SectionName));
        service.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        service.AddScoped<IUserRepository, UserRepository>();
        
        
        service.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserDbContext>()
            .AddDefaultTokenProviders();

        return service;
    }
}