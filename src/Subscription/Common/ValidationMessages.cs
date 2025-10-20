namespace Subscription.Common;

public static class ValidationMessages
{
    public const string UserIdRequired = "UserId is required.";
    public const string UserIdCannotBeNull = "UserId cannot be null.";

    public const string SubscriptionPlanIdRequired = "SubscriptionPlanId is required.";
    public const string SubscriptionPlanIdCannotBeNull = "SubscriptionPlanId cannot be null.";


    public class CreateSubscriptionPlanRequest
    {
        public const string NameRequired = "Name is required.";
        public const string NameCannotBeNull = "Name cannot be null.";
        public const string NameMaxLength = "Name cannot exceed 50 characters.";

        public const string DescriptionRequired = "Description is required.";
        public const string DescriptionCannotBeNull = "Description cannot be null.";
        public const string DescriptionMaxLength = "Description cannot exceed 300 characters.";

        public const string PriceGreaterThanZero = "Price must be greater than 0.";
        public const string DurationGreaterThanZero = "Duration (in days) must be greater than 0.";
    }

}

