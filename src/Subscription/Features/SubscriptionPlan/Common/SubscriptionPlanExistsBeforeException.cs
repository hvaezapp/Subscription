using System.Diagnostics.CodeAnalysis;

namespace Subscription.Features.SubscriptionPlan.Common;

public class SubscriptionPlanExistsBeforeException : Exception
{
    private const string _message = "This SubscriptionPlan with durationDays exists before and that name is {0}.";

    public SubscriptionPlanExistsBeforeException(string subscriptionName) : base(string.Format(_message , subscriptionName))
    {
    }

    [DoesNotReturn]
    public static void Throw(string subscriptionName)
    {
        throw new SubscriptionPlanExistsBeforeException(subscriptionName);
    }
}
