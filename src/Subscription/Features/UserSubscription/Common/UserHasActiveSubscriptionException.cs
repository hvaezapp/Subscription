using Subscription.Features.SubscriptionPlan.Common;
using System.Diagnostics.CodeAnalysis;

namespace Subscription.Features.UserSubscription.Common;

public class UserHasActiveSubscriptionException : Exception
{
    private const string _message = "You already have an active subscription Id: {0}, Name: {1}. Please deactivate it before creating a new one.";
    public UserHasActiveSubscriptionException(SubscriptionPlanId subscriptionPlanId ,  string subscriptionName) : base(string.Format(_message, subscriptionPlanId , subscriptionName))
    {
    }

    [DoesNotReturn]
    public static void Throw(SubscriptionPlanId subscriptionPlanId , string subscriptionName)
    {
        throw new UserHasActiveSubscriptionException(subscriptionPlanId , subscriptionName);
    }
}
