using FluentValidation;

namespace Subscription.Features.UserSubscription.DeactivateSubscription;

public class DeactivateSubscriptionRequestValidator : AbstractValidator<DeactivateSubscriptionRequest>
{
    public DeactivateSubscriptionRequestValidator()
    {
        RuleFor(x => x.UserId)
           .NotEmpty()
           .NotNull();

        RuleFor(x => x.SubscriptionPlanId)
           .NotEmpty()
           .NotNull();
    }
}
