namespace FacilityService.Models.Entities;

public class FacilityEntity
{
    public Guid Id { get; set; }
    public Guid TypeId { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public required int Price { get; set; }
    public Guid OwnerId { get; set; }

    public List<ApplicationEntity> Applications { get; set; } = new List<ApplicationEntity>();
    public AddressEntity? Address { get; set; }
    public List<RequestEntity> Requests { get; set; } = new List<RequestEntity>();
    public TypeEntity? Type { get; set; }
}