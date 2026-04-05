namespace Backend.Models.Entities;

public class Chat
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid FacilityId { get; set; }
    
    public List<Message> MessageEntities { get; set; } = new List<Message>();
    public List<ChatUser> ChatUsersEntities { get; set;} = new List<ChatUser>();
}