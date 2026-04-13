namespace Backend.DTOs;

public record GetMessage
{
    public Guid Id { get; set; }
    public Guid ChatId { get; set; }
    public string Text { get; set; } = string.Empty;
    public Guid SenderId { get; set; }
    public DateTime SendDate { get; set; }
    public bool IsSender { get; set; }
}