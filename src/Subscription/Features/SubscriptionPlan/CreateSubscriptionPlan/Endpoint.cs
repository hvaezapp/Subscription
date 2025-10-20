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
           .MapPost("/",
           async ([FromBody] CreateSubscriptionPlanRequest request, 
                  SubscriptionPlanService service,
                  CancellationToken ct) =>
           {
                var currencyId = await service.CreateAsync(request.Name, 
                                                            request.Description, 
                                                            request.Price ,
                                                            request.DurationDays, ct);

                return Results.Ok(new CreateSubscriptionPlanResponse(currencyId.ToString()));

           }).Validator<CreateSubscriptionPlanRequest>();
    }
}
