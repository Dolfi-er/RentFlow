using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Models.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasMany(m => m.ApllicationEntities)
            .WithOne(a => a.MessageEntity);

        builder.HasOne(m => m.ChatEntity)
            .WithMany(c => c.MessageEntities)
            .HasForeignKey(m => m.ChatId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(m => m.MessageStatusEntity)
            .WithMany(ms => ms.MessageEntities)
            .HasForeignKey(m => m.StatusId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasQueryFilter(m => !m.IsDeleted);
    }
}