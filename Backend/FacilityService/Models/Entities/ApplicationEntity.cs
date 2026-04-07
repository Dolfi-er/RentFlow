using MongoDB.Bson;

namespace FacilityService.Models.Entities;

public class ApplicationEntity
{
    public Guid Id { get; set; }
    public required ObjectId DocumentId { get; set; }
    public required string ContentType { get; set; }
    public required Guid FacilityId { get; set; }
    
    public FacilityEntity? Facility { get; set; }
}