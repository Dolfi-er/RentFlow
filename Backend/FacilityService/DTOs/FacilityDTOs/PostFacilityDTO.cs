namespace FacilityService.DTOs.FacilityDTOs;

public class PostFacilityDTO
{
    public required Guid TypeId { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public required int RentPrice { get; set; }

    public List<IFormFile> Files { get; set; } = new();

    public required string Town { get; set; }
    public required string Street { get; set; }
    public required int HouseNumber { get; set; }
    public required int Floor { get; set; }
    public required int Apartment { get; set; }
    public required int Entrance { get; set; }
}