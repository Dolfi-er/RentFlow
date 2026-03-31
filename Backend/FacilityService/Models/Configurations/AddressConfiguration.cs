using FacilityService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Models.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.HasKey(a => a.Id);
        
        builder.HasOne(a => a.Facility)
               .WithOne(f => f.Address)
               .HasForeignKey<AddressEntity>(a => a.Id)
               .OnDelete(DeleteBehavior.Cascade);
    }
}