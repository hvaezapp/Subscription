namespace Subscription.Features.UserSubscription.CreateSubscription;

public record CreateSubscriptionRequest
(
    Guid UserId,
    Guid SubscriptionPlanId
);

