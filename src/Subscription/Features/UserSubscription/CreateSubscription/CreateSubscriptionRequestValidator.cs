using FluentValidation;

namespace Subscription.Features.UserSubscription.CreateSubscription;

public class CreateSubscriptionRequestValidator : AbstractValidator<CreateSubscriptionRequest>
{
    public CreateSubscriptionRequestValidator()
    {
        RuleFor(x => x.UserId)
           .NotEmpty()
           .NotNull();

        RuleFor(x => x.SubscriptionPlanId)
           .NotEmpty()
           .NotNull();
    }
}
