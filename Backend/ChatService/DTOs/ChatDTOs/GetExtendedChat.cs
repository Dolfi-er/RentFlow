namespace Backend.DTOs;

public record GetExtendedChat
{
    public Guid ChatId { get; set; }
    public List<GetChatMessage> Messages { get; set; } = new List<GetChatMessage>();

}