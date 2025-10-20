using System.Diagnostics.CodeAnalysis;

namespace Subscription.Features.SubscriptionPlan.Common;

public class SubscriptionPlanNotFoundException : Exception
{
    private const string _message = "SubscriptionPlan with ID {0} not found.";
    public SubscriptionPlanNotFoundException(SubscriptionPlanId subscriptionPlanId) : base(string.Format(_message, subscriptionPlanId))
    {
    }

    [DoesNotReturn]
    public static void Throw(SubscriptionPlanId subscriptionPlanId)
    {
        throw new SubscriptionPlanNotFoundException(subscriptionPlanId);
    }
}
