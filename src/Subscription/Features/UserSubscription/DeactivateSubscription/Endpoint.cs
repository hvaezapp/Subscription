using Carter;
using Microsoft.AspNetCore.Mvc;
using Subscription.Common.Extensions;
using Subscription.Features.SubscriptionPlan.Common;
using Subscription.Features.UserSubscription.Common;

namespace Subscription.Features.UserSubscription.DeactivateSubscription;

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManager.Prefix)
                  .WithTags(FeatureManager.EndpointTagName)
                  .MapPut("/deactivate",
                  async ([FromBody] DeactivateSubscriptionRequest request,
                         UserSubscriptionService userSubscriptionService,
                         CancellationToken ct) =>
                  {
                      var userId = UserId.Create(request.UserId);
                      var subscriptionPlanId = SubscriptionPlanId.Create(request.SubscriptionPlanId);

                      await userSubscriptionService.Deactivate(userId, subscriptionPlanId, ct);

                      return Results.Ok("Subscription successfully deactivated");

                  }).Validator<DeactivateSubscriptionRequest>();
    }
}
