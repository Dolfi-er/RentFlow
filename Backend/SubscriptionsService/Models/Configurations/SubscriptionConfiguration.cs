using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubscriptionsService.Models.Entities;

namespace FacilityService.Models.Configurations;

public class SubscriptionConfiguration : IEntityTypeConfiguration<SubscriptionEntity>
{
    public void Configure(EntityTypeBuilder<SubscriptionEntity> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasMany(s => s.Applications)
               .WithOne(a => a.Subscription)
               .HasForeignKey(a => a.SubscriptionId);
    }
}