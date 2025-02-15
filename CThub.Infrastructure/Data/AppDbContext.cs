using System.Reflection;
using CThub.Domain.Abstractions;
using CThub.Domain.Models;
using CThub.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CThub.Infrastructure.Data;

public class AppDbContext: IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Rider> Riders => Set<Rider>();
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Stop> Stops => Set<Stop>();
    public DbSet<PrevStop> PrevStops => Set<PrevStop>();
    public DbSet<NextStop> NextStops => Set<NextStop>();
    public DbSet<Ride> Ride => Set<Ride>();
    public DbSet<Schedule> Schedule => Set<Schedule>();
    public DbSet<DriverQueue> DriverQueues => Set<DriverQueue>();
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.ApplyConfiguration(new RiderConfiguration());
        // builder.ApplyConfiguration(new DriverConfiguration());
        // builder.ApplyConfiguration(new IdentityUserConfiguration());
        // builder.ApplyConfiguration(new PrevStopConfiguration());
        // builder.ApplyConfiguration(new NextStopConfiguration());
        // builder.ApplyConfiguration(new StopConfiguration());
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("CThub");
        
    }
}