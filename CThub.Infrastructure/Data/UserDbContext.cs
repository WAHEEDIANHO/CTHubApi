using CThub.Domain.Abstractions;
using CThub.Domain.Models;
using CThub.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CThub.Infrastructure.Data;

public class UserDbContext: IdentityDbContext<User>
{
    public UserDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Rider> Riders => Set<Rider>();
    public DbSet<Driver> Drivers => Set<Driver>();
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new RiderConfiguration());
        builder.ApplyConfiguration(new DriverConfiguration());
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Identity");
        
    }
}