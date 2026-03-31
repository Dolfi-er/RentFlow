namespace Backend.Models.Entities;

public class Message
{
    public Guid Id { get; set; }
    public required Guid SenderId { get; set; }
    public required Guid ReceiverId { get; set; }
    public required Guid StatusId { get; set; }
    public required Guid ChatId { get; set; }
    public required string Text { get; set; }
    public required DateTime SendDate { get; set; }

    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    
    public Chat? ChatEntity { get; set; }
    public List<Application> ApllicationEntities { get; set; } = new List<Application>();

    public MessageStatus? MessageStatusEntity { get; set; }
}