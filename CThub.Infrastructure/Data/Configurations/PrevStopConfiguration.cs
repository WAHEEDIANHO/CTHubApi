using CThub.Domain.Models;
using CThub.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CThub.Infrastructure.Data.Configurations;

public class PrevStopConfiguration: IEntityTypeConfiguration<PrevStop>
{
    public void Configure(EntityTypeBuilder<PrevStop> builder)
    {
        builder.Property(pStop => pStop.PrevStopId)
            .HasConversion(pStop => pStop.Value,
                dbPStop => StopId.Of(dbPStop));

        builder.Property(pStop => pStop.PrevStopName)
            .HasConversion(
                pStop => pStop.Value,
                pStopDb => StopName.Of(pStopDb)
            );
        
        // builder.Property(pStop => pStop.StopId)
        //     .HasConversion(pStop => pStop.Value,
        //         dbPStop => StopId.Of(dbPStop));
        
        builder.HasKey(pStop => new { pStop.StopId, pStop.PrevStopId });
        builder.HasIndex(pstop => new { pstop.StopId, pstop.PrevStopId }).IsUnique();
    }
}