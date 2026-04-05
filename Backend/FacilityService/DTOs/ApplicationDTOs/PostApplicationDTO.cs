using MongoDB.Bson;

namespace FacilityService.DTOs.ApplicationDTOs;

public class PostApplicationDTO
{
    public required ObjectId DocumentId { get; set; }
    public required string ContentType { get; set; }
    public required Guid FacilityId { get; set; }
}