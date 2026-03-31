namespace FacilityService.Models.Entities;

public class TypeEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public List<FacilityEntity> Facilities { get; set; } = new List<FacilityEntity>();
}