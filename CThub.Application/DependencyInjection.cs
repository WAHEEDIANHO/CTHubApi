using System.Reflection;
using CThub.Application.ValidationBehaviour;
using Microsoft.Extensions.DependencyInjection;

namespace CThub.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddMediatR(
            opt =>
            {
                opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                opt.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            }
            );
        return services;
    }
}