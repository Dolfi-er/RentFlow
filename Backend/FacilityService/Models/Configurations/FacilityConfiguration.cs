using FacilityService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Models.Configurations;

public class FacilityConfiguration : IEntityTypeConfiguration<FacilityEntity>
{
    public void Configure(EntityTypeBuilder<FacilityEntity> builder)
    {
        builder.HasKey(f => f.Id);
        
        builder.HasMany(f => f.Applications)
               .WithOne(a => a.Facility)
               .HasForeignKey(a => a.FacilityId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.Requests)
               .WithOne(r => r.Facility)
               .HasForeignKey(r => r.FacilityId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}