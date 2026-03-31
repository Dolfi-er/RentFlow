using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Models.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(rt => rt.Id);
        
        builder.HasOne(rt => rt.UserEntity)
            .WithOne(u => u.RefreshTokenEntity)
            .HasForeignKey<RefreshToken>(rt => rt.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}