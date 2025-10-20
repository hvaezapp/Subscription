namespace Subscription.Features.UserSubscription.DeactivateSubscription;
public record DeactivateSubscriptionRequest
(
    Guid UserId,
    Guid SubscriptionPlanId
);

