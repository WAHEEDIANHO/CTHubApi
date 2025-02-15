using CThub.Domain.Models;
using CThub.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CThub.Infrastructure.Data.Configurations;

public class RiderConfiguration: IEntityTypeConfiguration<Rider>
{
    public void Configure(EntityTypeBuilder<Rider> builder)
    {
        builder.HasKey(r => r.UserId);
        // builder.Property(r => r.UserId)
        //     .HasConversion(
        //         rId => new Guid(rId),
        //         dbId => dbId.ToString()
        //     );

        // builder.Property(r => r.UserId)
        //     .HasConversion(
        //         rUserId => rUserId.Value,
        //         dbUserId => UserId.Of(dbUserId)
        //     );

        builder.HasOne(r => r.User)
            .WithOne()
            .HasForeignKey<Rider>(r => r.UserId);
        
        builder.HasMany(r => r.Rides)
            .WithOne()
            .HasForeignKey(r => r.RiderId);
    }
    
}