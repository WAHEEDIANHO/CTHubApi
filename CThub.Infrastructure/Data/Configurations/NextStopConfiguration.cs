using CThub.Domain.Models;
using CThub.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CThub.Infrastructure.Data.Configurations;

public class NextStopConfiguration: IEntityTypeConfiguration<NextStop>
{
    public void Configure(EntityTypeBuilder<NextStop> builder)
    {
        builder.Property(nStop => nStop.NextStopId)
            .HasConversion(nStop => nStop.Value,
                dbNStop => StopId.Of(dbNStop));

        builder.Property(nStop => nStop.NextStopName)
            .HasConversion(
                nStop => nStop.Value,
                nStopDb => StopName.Of(nStopDb)
            );
        
        // builder.Property(nStop => nStop.StopId)
        //     .HasConversion(nStop => nStop.Value,
        //         dbNStop => StopId.Of(dbNStop));
        
        builder.HasKey(nStop => new { nStop.StopId, nStop.NextStopId });
        builder.HasIndex(nStop => new { nStop.StopId, nStop.NextStopId }).IsUnique();
        
    }
}