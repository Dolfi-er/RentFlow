using MongoDB.Bson;

namespace Backend.Models.Entities;

public class Application
{
    public Guid Id { get; set; }
    public required ObjectId DocumentId { get; set; }
    public required string ContentType { get; set; }
    public required Guid MessageId { get; set; }
    
    public Message? MessageEntity { get; set; }
}