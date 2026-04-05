using MongoDB.Bson;

namespace FacilityService.DTOs.ApplicationDTOs;

public class GetApplicationDTO
{
    public required Guid Id { get; set; }
    public required ObjectId DocumentId { get; set; }
    public required string DocumentRef { get; set; }
    public required string ContentType { get; set; }
    public required Guid FacilityId { get; set; }
}