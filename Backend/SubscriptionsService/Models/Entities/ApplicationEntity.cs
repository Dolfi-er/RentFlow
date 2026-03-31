using MongoDB.Bson;

namespace SubscriptionsService.Models.Entities;

public class ApplicationEntity
{
    public Guid Id { get; set; }
    public required ObjectId DocumentId { get; set; }
    public required string ContentType { get; set; }
    public required Guid SubscriptionId { get; set; }
    
    public SubscriptionEntity? Subscription { get; set; }
}