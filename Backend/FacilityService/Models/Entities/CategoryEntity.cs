namespace FacilityService.Models.Entities;

public class CategoryEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public List<RequestEntity> RequestEntities { get; set; } = new List<RequestEntity>();
}