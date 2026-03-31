using FacilityService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Models.Configurations;

public class ApplicationConfiguration : IEntityTypeConfiguration<ApplicationEntity>
{
    public void Configure(EntityTypeBuilder<ApplicationEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.DocumentId)
               .HasConversion(
                    v => v.ToString(),
                    v => MongoDB.Bson.ObjectId.Parse(v)
               )
               .HasMaxLength(24)
               .IsRequired();
    }
}