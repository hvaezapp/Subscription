using Subscription.Features.SubscriptionPlan.Common;
using System.Diagnostics.CodeAnalysis;

namespace Subscription.Features.UserSubscription.Common;

public class UserSubscriptionNotFoundException : Exception
{
    private const string _message = "UserSubscription not found.";
    public UserSubscriptionNotFoundException() : base(string.Format(_message))
    {
    }

    [DoesNotReturn]
    public static void Throw()
    {
        throw new UserSubscriptionNotFoundException();
    }
}
