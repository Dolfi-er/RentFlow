using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Models.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.RoleEntity)
            .WithMany(r => r.UsersEntities)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(u => u.RefreshTokenEntity)
            .WithOne(rt => rt.UserEntity);

        builder.HasOne(u => u.UserInfoEntity)
            .WithOne(ui => ui.UserEntity);
    }
}