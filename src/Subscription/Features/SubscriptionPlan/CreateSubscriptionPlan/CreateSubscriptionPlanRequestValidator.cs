using FluentValidation;

namespace Subscription.Features.SubscriptionPlan.CreateSubscriptionPlan;

public class CreateSubscriptionPlanRequestValidator : AbstractValidator<CreateSubscriptionPlanRequest>
{
    public CreateSubscriptionPlanRequestValidator()
    {

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);


        RuleFor(x => x.Description)
           .NotEmpty()
           .NotNull()
           .MaximumLength(300);


        RuleFor(x => x.Price)
                .GreaterThan(0);


        RuleFor(x => x.DurationDays)
                 .GreaterThan(0);
    }
}


