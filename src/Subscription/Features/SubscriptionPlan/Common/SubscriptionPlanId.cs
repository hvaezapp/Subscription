namespace Subscription.Features.SubscriptionPlan.Common;

public record SubscriptionPlanId(Guid Value)
{
    public static SubscriptionPlanId CreateUniqueId() => new (Guid.NewGuid());

    public static SubscriptionPlanId Create(Guid value) => new (value);

    public override string ToString()
    {
        return Value.ToString();
    }
};
