using CThub.Api;
using CThub.Application;
using CThub.Infrastructure;
using CThub.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
        .AddInfrastructure(builder.Configuration)
        .AddApplication()
        .AppApiServices(builder.Configuration);
}

var app = builder.Build();
{
    app.UseApiServices();
    if (app.Environment.IsDevelopment())
    {
        await app.InitialiseDatabaseAsync();
    }
    app.Run();
}




