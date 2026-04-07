namespace Backend.DTOs;

public record PutMessage
{
    public Guid Id { get; set; }
    public string Text { get; set; } = null!;
}