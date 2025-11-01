using Carter;
using Microsoft.AspNetCore.Mvc;
using Subscription.Common.Extensions;
using Subscription.Features.SubscriptionPlan.Common;

namespace Subscription.Features.SubscriptionPlan.CreateSubscriptionPlan;

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManager.Prefix)
           .WithTags(FeatureManager.EndpointTagName)
           .MapPost("/create",
           async ([FromBody] CreateSubscriptionPlanRequest request, 
                  SubscriptionPlanService subscriptionPlanService,
                  CancellationToken ct) =>
           {
                var subscriptionPlanId = await subscriptionPlanService.Create(request.Name, 
                                                            request.Description, 
                                                            request.Price ,
                                                            request.DurationDays, ct);

                return Results.Ok(new CreateSubscriptionPlanResponse(subscriptionPlanId.ToString()));

           }).Validator<CreateSubscriptionPlanRequest>();
    }
}
