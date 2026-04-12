using FacilityService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacilityService.Models.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.HasKey(a => a.Id);
    }
}