using Backend.Models.Configurations;
using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles{ get; set; }
    public DbSet<UserInfo> UserInfos { get; set; }
    public DbSet<RefreshToken> RefreshTokens{ get; set; }

    public Context(DbContextOptions<Context> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new RefreshTokenConfiguration());
        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new UserInfoConfiguration());
    }
}