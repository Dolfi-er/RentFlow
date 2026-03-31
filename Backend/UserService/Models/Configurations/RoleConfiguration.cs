using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Models.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void  Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.HasMany(r => r.UsersEntities)
            .WithOne(u => u.RoleEntity);
    }
}