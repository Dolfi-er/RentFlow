using MongoDB.Bson;

namespace Backend.DTOs;

public record PostApplicationDTO
{
    public required ObjectId DocumentId { get; set; }
    public required string ContentType { get; set; }
    public required Guid MessageId { get; set; }
}