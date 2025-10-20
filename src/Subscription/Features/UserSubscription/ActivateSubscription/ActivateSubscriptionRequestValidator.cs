using FluentValidation;

namespace Subscription.Features.UserSubscription.ActivateSubscription;

public class ActivateSubscriptionRequestValidator : AbstractValidator<ActivateSubscriptionRequest>
{
    public ActivateSubscriptionRequestValidator()
    {
        RuleFor(x => x.UserId)
           .NotEmpty()
           .NotNull();

        RuleFor(x => x.SubscriptionPlanId)
           .NotEmpty()
           .NotNull();
    }
}
