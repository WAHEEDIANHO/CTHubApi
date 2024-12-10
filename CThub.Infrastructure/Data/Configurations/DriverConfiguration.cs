using CThub.Domain.Models;
using CThub.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CThub.Infrastructure.Data.Configurations;

public class DriverConfiguration: IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {

        builder.HasKey(d => d.UserId);
        // builder.Property(d => d.Id)
        //     .HasConversion(
        //         driverId => driverId.Value,
        //         dbId => DriverId.Of(dbId)
        //     );
        
        // builder.Property(r => r.UserId)
        //     .HasConversion(
        //         rUserId => rUserId.Value,
        //         dbUserId => UserId.Of(dbUserId)
        //     );

        builder.Property(d => d.DriverNo)
            .HasConversion(
                driverNo => driverNo.Value,
                driverDbNo => DriverNo.Of(driverDbNo)
            );

        builder.HasOne(d => d.User)
            .WithOne()
            .HasForeignKey<Driver>(d => d.UserId);

        builder.ComplexProperty(
            d => d.Vehincle, vehincleBuilder =>
            {
                vehincleBuilder.Property(v => v.Name)
                    .HasMaxLength(50)
                    .IsRequired();

                vehincleBuilder.Property(v => v.Capacity)
                    .IsRequired();

                vehincleBuilder.Property(v => v.Model)
                    .HasMaxLength(50)
                    .IsRequired();

                vehincleBuilder.Property(v => v.Type)
                    .HasMaxLength(50)
                    .IsRequired();
            }
        );

        // builder.HasOne<User>()
            // .WithOne();

    }
}