using System.Diagnostics.CodeAnalysis;

namespace Subscription.Features.SubscriptionPlan.Common;

public class SubscriptionPlanExistBeforeException : Exception
{
    private const string _message = "This SubscriptionPlan with DurationDays Exists Before.";

    public SubscriptionPlanExistBeforeException() : base(_message)
    {
    }

    [DoesNotReturn]
    public static void Throw()
    {
        throw new SubscriptionPlanExistBeforeException();
    }
}
