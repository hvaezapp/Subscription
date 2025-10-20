namespace Subscription.Features.SubscriptionPlan.Common;

public class SubscriptionPlan
{
    public SubscriptionPlanId Id { get; private set; } = null!;
    public string Name { get; private set; } =  null!;
    public string Description { get; private set; } = null!;
    public decimal Price { get; private set; }
    public int DurationDays { get; private set; }
    public ICollection<UserSubscription.Common.UserSubscription> UserSubscriptions { get; private set; } = default!;

}
