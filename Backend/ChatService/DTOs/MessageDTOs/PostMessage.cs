namespace Backend.DTOs;

public record PostMessage
{
    public Guid StatusId { get; set; }
    public Guid ChatId { get; set; }
    public string Text { get; set; } = null!;
    public List<IFormFile> Files { get; set; } = new();
}