using System.Reflection;
using CThub.Domain.Abstractions;
using CThub.Domain.Models;
using CThub.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CThub.Infrastructure.Data;

public class ApplicationDbContext: DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Rider> Riders => Set<Rider>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Entity<User>(entity =>
            entity.ToTable("AspNetUsers")
        );
        builder.ApplyConfiguration(new RiderConfiguration());
        builder.ApplyConfiguration(new DriverConfiguration());
        base.OnModelCreating(builder);
    }
}