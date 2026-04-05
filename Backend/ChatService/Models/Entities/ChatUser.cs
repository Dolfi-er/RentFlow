namespace Backend.Models.Entities;

public class ChatUser
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }

    public Chat? ChatEntity { get; set; }
}