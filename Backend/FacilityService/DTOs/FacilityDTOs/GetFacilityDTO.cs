using FacilityService.DTOs.ApplicationDTOs;

namespace FacilityService.DTOs.FacilityDTOs;

public class GetFacilityDTO
{
    public required Guid Id { get; set; }
    public required string TypeName { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public required int RentPrice { get; set; }
    public required Guid OwnerId { get; set; }
    
    public List<GetApplicationDTO> Applications { get; set; } = new List<GetApplicationDTO>();
}