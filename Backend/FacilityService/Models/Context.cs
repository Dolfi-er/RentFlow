using FacilityService.Models.Configurations;
using FacilityService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacilityService.Models;

public class Context : DbContext
{
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<ApplicationEntity> Applications { get; set; }
    public DbSet<FacilityEntity> Facilities { get; set; }
    public DbSet<RequestEntity> Requests { get; set; }
    public DbSet<StatusEntity> Statuses { get; set; }
    public DbSet<TypeEntity> Types { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new AddressConfiguration());
        builder.ApplyConfiguration(new ApplicationConfiguration());
        builder.ApplyConfiguration(new FacilityConfiguration());
        builder.ApplyConfiguration(new RequestConfiguration());
        builder.ApplyConfiguration(new StatusConfiguration());
        builder.ApplyConfiguration(new TypeConfiguration());
    }
}