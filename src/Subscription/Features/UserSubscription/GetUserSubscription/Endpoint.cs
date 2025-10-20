using Carter;
using Microsoft.AspNetCore.Mvc;
using Subscription.Features.UserSubscription.Common;

namespace Subscription.Features.UserSubscription.GetUserSubscription;

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app
          .MapGroup(FeatureManager.Prefix)
          .WithTags(FeatureManager.EndpointTagName)
          .MapGet("/{user_id:guid:required}/subscriptions",
          async ([FromRoute(Name = "user_id")] Guid Id,
                 UserSubscriptionService userSubscriptionService,
                 CancellationToken ct) =>
          {
              var userId = UserId.Create(Id);
              var userSubscriptions = await userSubscriptionService.GetActiveUserSubscriptionsByUserId(userId , ct);
              return Results.Ok(userSubscriptions);
          });
    }
}
