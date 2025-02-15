using CThub.Domain.Enums;
using CThub.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CThub.Infrastructure.Data.Configurations;

public class IdentityUserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.UserRole)
            .HasDefaultValue(UserRole.User)
            .HasConversion(
                userRole => userRole.ToString(),
                dbUserRole => (UserRole)Enum.Parse(typeof(UserRole), dbUserRole));
    }
}