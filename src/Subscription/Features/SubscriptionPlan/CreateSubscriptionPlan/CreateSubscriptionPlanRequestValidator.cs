using FluentValidation;
using Subscription.Common;

namespace Subscription.Features.SubscriptionPlan.CreateSubscriptionPlan;

public class CreateSubscriptionPlanRequestValidator : AbstractValidator<CreateSubscriptionPlanRequest>
{
    public CreateSubscriptionPlanRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationMessages.CreateSubscriptionPlanRequest.NameRequired)
            .NotNull().WithMessage(ValidationMessages.CreateSubscriptionPlanRequest.NameCannotBeNull)
            .MaximumLength(50).WithMessage(ValidationMessages.CreateSubscriptionPlanRequest.NameMaxLength);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(ValidationMessages.CreateSubscriptionPlanRequest.DescriptionRequired)
            .NotNull().WithMessage(ValidationMessages.CreateSubscriptionPlanRequest.DescriptionCannotBeNull)
            .MaximumLength(300).WithMessage(ValidationMessages.CreateSubscriptionPlanRequest.DescriptionMaxLength);

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage(ValidationMessages.CreateSubscriptionPlanRequest.PriceGreaterThanZero);

        RuleFor(x => x.DurationDays)
            .GreaterThan(0).WithMessage(ValidationMessages.CreateSubscriptionPlanRequest.DurationGreaterThanZero);

    }
}


