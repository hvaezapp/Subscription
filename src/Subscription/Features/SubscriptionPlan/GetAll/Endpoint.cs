using Carter;
using Subscription.Features.SubscriptionPlan.Common;
using Subscription.Infrastructure.Persistence.Context;

namespace Subscription.Features.SubscriptionPlan.GetAll;

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app
          .MapGroup(FeatureManager.Prefix)
          .WithTags(FeatureManager.EndpointTagName)
          .MapGet("/getAll",
          async (SubscriptionPlanService subscriptionPlanService, CancellationToken ct) =>
          {
              var subscriptionPlans = await subscriptionPlanService.GetAll(ct);
              return Results.Ok(subscriptionPlans);
          });
    }
}
