using FacilityService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacilityService.Models.Configurations;

public class TypeConfiguration : IEntityTypeConfiguration<TypeEntity>
{
    public void Configure(EntityTypeBuilder<TypeEntity> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.HasMany(t => t.Facilities)
               .WithOne(f => f.Type)
               .HasForeignKey(f => f.TypeId);
    }
}