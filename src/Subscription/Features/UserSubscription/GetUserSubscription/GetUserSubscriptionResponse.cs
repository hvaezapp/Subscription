namespace Subscription.Features.UserSubscription.GetUserSubscription;

public record GetUserSubscriptionResponse
(
    string UserSubscriptionId,
    string SubscriptionPlanId,
    string Name,
    string Description,
    decimal Price,
    int DurationDays,
    DateTime StartDate,
    DateTime EndDate,
    bool IsActive
);
