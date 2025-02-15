using CThub.Domain.Models;
using CThub.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CThub.Infrastructure.Data.Configurations;

public class StopConfiguration: IEntityTypeConfiguration<Stop>
{
    public void Configure(EntityTypeBuilder<Stop> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .HasConversion(
                sId => sId.Value,
                dbId => StopId.Of(dbId)
            );

        builder.Property(s => s.StopName)
            .HasConversion(
                sName => sName.Value, 
                dbSName => StopName.Of(dbSName)
            );
        
        builder.HasIndex(s => s.StopName)
            .IsUnique();

        builder.HasMany(s => s.PrevStops)
            .WithOne()
            .HasForeignKey(s => s.StopId);
        
        // builder.Navigation( s=> s.PrevStops)
        //     .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(s => s.NextStops)
            .WithOne()
            .HasForeignKey(s => s.StopId);
    }
}