using MongoDB.Bson;

namespace Backend.DTOs;

public record GetApplicationDTO
{
    public required Guid Id { get; set; }
    public required ObjectId DocumentId { get; set; }
    public required string DocumentRef { get; set; }
    public required string ContentType { get; set; }
    public required Guid MessageId { get; set; }
}