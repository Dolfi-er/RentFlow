namespace SubscriptionsService.Models.Entities;

public class SubscriptionEntity
{
    public Guid Id { get; set; }
    public Guid FacilityId { get; set; }
    public Guid UserId { get; set; }
    public required DateTime PaymentDate { get; set; }
    public required DateTime ExpireDate { get; set; }
    public required int Price { get; set; }

    public List<ApplicationEntity> Applications { get; set; } = new List<ApplicationEntity>();
}