using CThub.Application.Authentication.Repository;
using CThub.Domain.Exceptions;
using CThub.Domain.Models;
using CThub.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// using User = CThub.Domain.Entities.User;

namespace CThub.Infrastructure.Persistence;

public class UserRepository(
    AppDbContext context, 
    UserManager<User> userManager, 
    RoleManager<IdentityRole> roleManager
    ): IUserRepository
{
    public async Task AddUser(User user, string password)
    {
        if (await userManager.FindByEmailAsync(user.Email!) is not User exUser)
        { 
            user.UserName = user.Email;
           var resp = await userManager.CreateAsync(user, password);
           if(resp.Succeeded) return;
           throw new UserException(resp.Errors.ElementAt(0).Description);
        }
        throw new DuplicationError($"user {user.Email} already exist");
    }

    public async Task AddRider(User user, Rider rider)
    {
        if (!roleManager.RoleExistsAsync("rider").GetAwaiter().GetResult()) await roleManager.CreateAsync(new IdentityRole("rider"));
        // var theUser = await userManager.FindByEmailAsync(user.Email!);

        await userManager.AddToRoleAsync(user, "rider");
        context.Riders.Add(rider);
        await context.SaveChangesAsync();
    }

    public async Task AddDriver(User user, Driver driver)
    {
        if (!(await roleManager.RoleExistsAsync("driver"))) await roleManager.CreateAsync(new IdentityRole("driver"));

        await userManager.AddToRoleAsync(user, "driver");
        int driverCount = await context.Drivers.CountAsync();
        driver.SetDriverNo(++driverCount);
        context.Drivers.Add(driver);
        await context.SaveChangesAsync();
    }
    // public Task AddUser(User user)
    // {   
    //     _db.Add(user);
    // }
    //
    public async Task<User?> GetUserByEmail(string email)
    {
        // userManager
        var user = await userManager.FindByEmailAsync(email);
        return user;
    }

    public Task<User?> GetUserById(string userId)
    {
       return userManager.FindByIdAsync(userId);
        // return user;
    }

    public async Task<bool> CheckPassword(User user, string password)
    {
        return await userManager.CheckPasswordAsync(user, password);
    }
}