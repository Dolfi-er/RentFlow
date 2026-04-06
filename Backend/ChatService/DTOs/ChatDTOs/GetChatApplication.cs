
using MongoDB.Bson;

namespace Backend.DTOs;

public record GetChatApplicationDTO
{
    public required Guid Id { get; set; }
    public required ObjectId DocumentId { get; set; }
    public required string DocumentRef { get; set; }
}