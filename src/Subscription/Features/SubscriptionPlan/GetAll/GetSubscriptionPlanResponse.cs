namespace Subscription.Features.SubscriptionPlan.GetAll;

public record GetSubscriptionPlanResponse
(
    string Id,
    string Name,
    string Description,
    decimal Price,
    int DurationDays
);
