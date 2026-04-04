namespace FacilityService.DTOs.FacilityDTOs;

public class PostFacilityDTO
{
    public required Guid TypeId { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public required int RentPrice { get; set; }
}