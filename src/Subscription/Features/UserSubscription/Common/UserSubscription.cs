using Subscription.Features.SubscriptionPlan.Common;

namespace Subscription.Features.UserSubscription.Common;

public class UserSubscription
{
    public UserSubscriptionId Id { get; private set; } = null!;
    public UserId UserId { get; private set; } = null!;
    public SubscriptionPlanId SubscriptionPlanId { get; private set; } = null!;
    public SubscriptionPlan.Common.SubscriptionPlan SubscriptionPlan { get; private set; } = null!;
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsActive { get; private set; }

}
