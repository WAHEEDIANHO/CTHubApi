using CThub.Domain.Models;
using CThub.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CThub.Infrastructure.Data.Configurations;

public class StopConfiguration
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

        // builder.HasMany(s => s.PrevStops)
        //     .WithOne()Auditable
        //     .HasForeignKey(s => s.Id);
    }
}