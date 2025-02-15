using CThub.Api;
using CThub.Application;
using CThub.Infrastructure;
using CThub.Infrastructure.Extensions;
using CThub.Infrastructure.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

{
    builder.WebHost.UseUrls("http://0.0.0.0:5125");
    builder.Services.AddSignalR();
    builder.Services
        .AddInfrastructure(builder.Configuration)
        .AddApplication()
        .AppApiServices(builder.Configuration);
}

var app = builder.Build();
{
    app.UseApiServices();
    Console.WriteLine(app.Environment);
    if (app.Environment.IsDevelopment())
    {
        await app.InitialiseDatabaseAsync( );
    }
    app.Run();
}




