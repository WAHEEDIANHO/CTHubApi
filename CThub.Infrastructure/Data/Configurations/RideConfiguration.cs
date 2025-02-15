using CThub.Domain.Models;
using CThub.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehincle = CThub.Domain.Enums.Vehincle;

namespace CThub.Infrastructure.Data.Configurations;

public class RideConfiguration: IEntityTypeConfiguration<Ride>
{
    public void Configure(EntityTypeBuilder<Ride> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .HasConversion(
                x => x.Value,
                dbId => RideId.Of(dbId)
            );

        builder.Property(x => x.StartStopId)
            .HasConversion(
                    r => r.Value,
                    dbRid => StopId.Of(dbRid)
                );
        builder.Property(x => x.EndStopId)
            .HasConversion(
                r => r.Value,
                dbRid => StopId.Of(dbRid)
            );
        
        builder.Property(x => x.RideType)
            .HasConversion(
                rideType => rideType.ToString(),
                dbRideType => (Domain.Enums.Ride)Enum.Parse(typeof(Domain.Enums.Ride), dbRideType)
            );

        builder.Property(r => r.VehincleType)
            .HasConversion(
                vehincletype => vehincletype.ToString(),
                dbVehincletype => (Vehincle)Enum.Parse(typeof(Vehincle), dbVehincletype)
            );
        
        // builder.HasOne(r => r.)
    }
}