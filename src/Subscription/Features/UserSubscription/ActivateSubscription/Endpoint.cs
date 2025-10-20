using Carter;
using Microsoft.AspNetCore.Mvc;
using Subscription.Common.Extensions;
using Subscription.Features.SubscriptionPlan.Common;
using Subscription.Features.UserSubscription.Common;

namespace Subscription.Features.UserSubscription.ActivateSubscription;

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManager.Prefix)
           .WithTags(FeatureManager.EndpointTagName)
           .MapPost("/activate",
           async ([FromBody] ActivateSubscriptionRequest request,
                  UserSubscriptionService userSubscriptionService,
                  CancellationToken ct) =>
           {
               var userId = UserId.Create(request.UserId);
               var subscriptionPlanId = SubscriptionPlanId.Create(request.SubscriptionPlanId);

               await userSubscriptionService.Activate(userId, subscriptionPlanId, ct);

               return Results.Ok("Subscription successfully activated");

           }).Validator<ActivateSubscriptionRequest>();
    }
}
