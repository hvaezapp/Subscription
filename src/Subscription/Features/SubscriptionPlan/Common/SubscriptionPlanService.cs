using Microsoft.EntityFrameworkCore;
using Subscription.Infrastructure.Persistence.Context;

namespace Subscription.Features.SubscriptionPlan.Common;

public class SubscriptionPlanService(SubscriptionDbContext dbContext)
{
    private readonly SubscriptionDbContext _dbContext = dbContext;

    public async Task<SubscriptionPlanId> CreateAsync(string name , string description  , 
                                                      decimal price , int durationDays , 
                                                      CancellationToken ct)
    {
        var subscriptionPlan = SubscriptionPlan.Create(name, description, price , durationDays);

        _dbContext.SubscriptionPlans.Add(subscriptionPlan);
        await _dbContext.SaveChangesAsync(ct);

        return subscriptionPlan.Id;
    }
}
