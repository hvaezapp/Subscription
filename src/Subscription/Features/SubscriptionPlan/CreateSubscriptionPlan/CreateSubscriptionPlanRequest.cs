namespace Subscription.Features.SubscriptionPlan.CreateSubscriptionPlan;

public record CreateSubscriptionPlanRequest
(
    string Name,
    string Description,
    decimal Price, 
    int DurationDays
);

