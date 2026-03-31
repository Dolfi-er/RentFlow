namespace FacilityService.Models.Entities;

public class AddressEntity
{
    public Guid Id { get; set; }
    public required string Town { get; set; }
    public required string Street { get; set; }
    public required int HouseNumber { get; set; }
    public required int Floor { get; set; }
    public required int Apartment { get; set; }
    public required int Entrance { get; set; }

    public FacilityEntity? Facility { get; set; }
}