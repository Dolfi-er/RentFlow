namespace FacilityService.Models.Entities;

public class RequestEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public required Guid StatusId { get; set; }
    public required Guid FacilityId { get; set; }
    
    public FacilityEntity? Facility { get; set; }
    public StatusEntity? Status { get; set; }
}