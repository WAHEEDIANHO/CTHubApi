using CThub.Domain.Models;
using CThub.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CThub.Infrastructure.Data.Configurations;

public class ScheduleConfiguration: IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasConversion(
                sId => sId.Value,
                dbId => ScheduleId.Of(dbId)
            );

        // builder.Property(s => s.RideType)
        //     .HasConversion(
        //         rideType => rideType.ToString(),
        //         dbRideType => (Domain.Enums.Ride)Enum.Parse(typeof(Domain.Enums.Ride), dbRideType));

        builder.Property(s => s.Path);
        builder.HasIndex(s => s.Path).IsUnique();

        builder.HasMany(s => s.User)
            .WithMany();
        // .HasForeignKey(s => s.ScheduleId)
    }
}