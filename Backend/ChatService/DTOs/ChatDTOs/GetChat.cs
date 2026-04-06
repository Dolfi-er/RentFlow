namespace Backend.DTOs;

public record GetChat
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}