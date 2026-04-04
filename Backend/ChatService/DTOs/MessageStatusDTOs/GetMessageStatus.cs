namespace Backend.DTOs;

public record GetMessageStatus
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}