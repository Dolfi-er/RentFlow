using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Models.Configurations;

public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.MessageEntity)
            .WithMany(m => m.ApllicationEntities)
            .HasForeignKey(a => a.MessageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(a => a.DocumentId)
               .HasConversion(
                    v => v.ToString(),
                    v => MongoDB.Bson.ObjectId.Parse(v)
               )
               .HasMaxLength(24)
               .IsRequired();
               
        builder.HasQueryFilter(a => !a.MessageEntity!.IsDeleted);
    }
}