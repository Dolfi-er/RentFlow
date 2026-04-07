namespace Backend.DTOs;

public record PostChat
{
    public string Name { get; set; } = null!;
    public Guid FacilityId { get; set; }
    public Guid User1Id { get; set; }
    public Guid User2Id { get; set;}
}