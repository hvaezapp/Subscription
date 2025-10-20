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
    public DateTime CreatedAt { get; private set; }
    public bool IsActive { get; private set; }



    public static UserSubscription Create(UserId userId, SubscriptionPlanId subscriptionPlanId, int durationDays)
      => new()
      {
          Id = UserSubscriptionId.CreateUniqueId(),
          UserId = userId,
          SubscriptionPlanId = subscriptionPlanId,
          StartDate = DateTime.Now,
          EndDate = DateTime.Now.AddDays(durationDays),
          CreatedAt = DateTime.Now,
          IsActive = true
      };

    internal void Deactive()
    {
        IsActive = false;
    }

    private UserSubscription()
    {

    }

}
