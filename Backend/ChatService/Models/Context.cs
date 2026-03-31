using Backend.Models.Configurations;
using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public class Context : DbContext
{
    public DbSet<Application> Entities { get; set; } =null!;
    public DbSet<Chat> Chats{ get; set; } =null!;
    public DbSet<Message> Messages{ get; set; } =null!;
    public DbSet<MessageStatus> MessagesStatuses { get; set; } =null!;
    public Context(DbContextOptions<Context> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ApplicationConfiguration());
        builder.ApplyConfiguration(new ChatConfiguration());
        builder.ApplyConfiguration(new MessageConfiguration());
        builder.ApplyConfiguration(new MessageStatusConfiguration());
    }
}