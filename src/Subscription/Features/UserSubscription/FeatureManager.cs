using ServiceCollector.Abstractions;
using Subscription.Features.UserSubscription.Common;

namespace Subscription.Features.UserSubscription;

public abstract class FeatureManager
{
    public const string EndpointTagName = "UserSubscription";
    public const string Prefix = "/userSubscriptions";

    public class ServiceManager : IServiceDiscovery
    {
        public void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<UserSubscriptionService>();
        }
    }
}
