using FacilityService.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using SubscriptionsService.Models.Entities;

namespace FacilityService.Models;

public class Context : DbContext
{
    public DbSet<ApplicationEntity> Applications { get; set; }
    public DbSet<SubscriptionEntity> Subscriptions { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ApplicationConfiguration());
        builder.ApplyConfiguration(new SubscriptionConfiguration());
    }
}