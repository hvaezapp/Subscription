namespace Subscription.Persistence.Context;

public class SubscriptionDbContextSchema
{
    public const string DefaultDecimalColumnType = "decimal(18,6)";

    public static class SubscriptionPlan
    {
        public const string TableName = "SubscriptionPlans";
    }

    public static class UserSubscription
    {
        public const string TableName = "UserSubscriptions";
    }

}
