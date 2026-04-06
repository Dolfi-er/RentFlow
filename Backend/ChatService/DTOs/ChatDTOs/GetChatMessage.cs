namespace Backend.DTOs;

public record GetChatMessage
{
    public Guid MessageId { get; set; }
    public string Message { get; set; } = null!;
    public DateTime  DateTime { get; set; }
    public bool IsSender { get; set; }
    public string Status { get; set; } = null!;
}