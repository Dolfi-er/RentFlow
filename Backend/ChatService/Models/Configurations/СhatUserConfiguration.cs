using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Models.Configurations;

public class ChatUserConfiguration : IEntityTypeConfiguration<ChatUser>
{
    public void Configure(EntityTypeBuilder<ChatUser> builder)
    {
        builder.HasKey(cu => cu.Id);

        builder.HasOne(cu => cu.ChatEntity)
            .WithMany(c => c.ChatUsersEntities)
            .HasForeignKey(cu => cu.ChatId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}