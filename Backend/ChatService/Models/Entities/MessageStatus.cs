namespace Backend.Models.Entities;

public class MessageStatus
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public List<Message> MessageEntities { get; set; } = new List<Message>();
}