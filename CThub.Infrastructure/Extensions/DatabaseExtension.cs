using CThub.Domain.Abstractions;
using CThub.Domain.Models;
using CThub.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace CThub.Infrastructure.Extensions;

public static class DatabaseExtension
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        context.Database.MigrateAsync().GetAwaiter().GetResult();

        // await SeedAsync(context);
        // updateUserAsync(context, userManager);
        await SeedUserAsync(userManager, roleManager);
        await SeedStopAsync(context);
        await AddStopRelationShipAsync(context);
    }

    // private static async Task SeedAsync(ApplicationDbContext context)
    // {
    //     // context.RI
    // }

    private static async Task SeedUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        var users = InitialData.Users;
        foreach (var user in users)
        {
            // string roleName = user.
            if (!await roleManager.RoleExistsAsync("rider"))
            {
                await roleManager.CreateAsync(new IdentityRole("Rider"));
            }
            var isUser = await userManager.FindByEmailAsync(user.Email!);

            if (isUser == null)
            {
                user.UserName = user.Email;
                var isUserCreate = await userManager.CreateAsync(user, "String@123");
                if(isUserCreate.Succeeded) Console.WriteLine("Successful");
                else Console.WriteLine("Failed");
                // if(res.Succeeded) await userManager.AddToRoleAsync(user, "")
                
            }  
        }
    }

    private static async Task SeedStopAsync(AppDbContext context)
    {
        if (!await context.Stops.AnyAsync())
        {
            await context.Stops.AddRangeAsync(InitialData.Stops);
            await context.SaveChangesAsync();
        }
    }

    private static async Task AddStopRelationShipAsync(AppDbContext context)
    {
        if (!await context.PrevStops.AnyAsync())
        {
            await context.PrevStops.AddRangeAsync(InitialData.PrevStops);
            await context.SaveChangesAsync();
        }
    }
}