namespace Subscription.Features.UserSubscription.Common;

public record UserSubscriptionId(Guid Value)
{
    public static UserSubscriptionId CreateUniqueId() => new(Guid.NewGuid());

    public static UserSubscriptionId Create(Guid value) => new(value);

    public override string ToString()
    {
        return Value.ToString();
    }
};
