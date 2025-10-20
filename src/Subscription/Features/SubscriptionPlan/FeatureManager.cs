using ServiceCollector.Abstractions;
using Subscription.Features.SubscriptionPlan.Common;

namespace Subscription.Features.SubscriptionPlan;

public abstract class FeatureManager
{
    public const string EndpointTagName = "SubscriptionPlan";
    public const string Prefix = "/subscriptionPlans";

    public class ServiceManager : IServiceDiscovery
    {
        public void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<SubscriptionPlanService>();
        }
    }
}
