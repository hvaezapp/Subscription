using FluentValidation;
using Subscription.Common;

namespace Subscription.Features.UserSubscription.ActivateSubscription;

public class ActivateSubscriptionRequestValidator : AbstractValidator<ActivateSubscriptionRequest>
{
    public ActivateSubscriptionRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage(ValidationMessages.UserIdRequired)
            .NotNull().WithMessage(ValidationMessages.UserIdCannotBeNull);


        RuleFor(x => x.SubscriptionPlanId)
            .NotEmpty().WithMessage(ValidationMessages.SubscriptionPlanIdRequired)
            .NotNull().WithMessage(ValidationMessages.SubscriptionPlanIdCannotBeNull);
    }
}
