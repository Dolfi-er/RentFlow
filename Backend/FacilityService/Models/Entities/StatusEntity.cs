namespace FacilityService.Models.Entities;

public class StatusEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public List<RequestEntity> Requests { get; set; } = new List<RequestEntity>();
}