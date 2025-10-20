namespace Subscription.Features.UserSubscription.ActivateSubscription;

public record ActivateSubscriptionRequest
(
    Guid UserId,
    Guid SubscriptionPlanId
);

