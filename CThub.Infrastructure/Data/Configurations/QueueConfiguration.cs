using CThub.Domain.Enums;
using CThub.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CThub.Infrastructure.Data.Configurations;

public class QueueConfiguration: IEntityTypeConfiguration<DriverQueue>
{
    public void Configure(EntityTypeBuilder<DriverQueue> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.DriverId);
        builder.Property(q => q.Token);

        builder.Property(q => q.QueueTime);

        builder.Property(q => q.Vehincle)
            .HasConversion(
                q => q.ToString(),
                qdb => (Vehincle)Enum.Parse(typeof(Vehincle), qdb)
            );

        builder.HasOne(x => x.Driver)
            .WithOne()
            .HasForeignKey<DriverQueue>(x => x.DriverId);

        builder.HasIndex(q => q.DriverId)
            .IsUnique();

        builder.ComplexProperty(q => q.Location, qbuider =>
        {
            qbuider.Property(b => b.Latitude);
            qbuider.Property(b => b.Longitude);
        });
    }
}