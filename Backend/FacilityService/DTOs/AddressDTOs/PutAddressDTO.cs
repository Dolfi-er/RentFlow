namespace FacilityService.DTOs.AddressDTOs;

public class PutAddressDTO
{
    public required string Town { get; set; }
    public required string Street { get; set; }
    public required int HouseNumber { get; set; }
    public required int Floor { get; set; }
    public required int Apartment { get; set; }
    public required int Entrance { get; set; }
}