using Microsoft.EntityFrameworkCore;
using Subscription.Features.SubscriptionPlan.GetAll;
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


    public async Task<IEnumerable<GetSubscriptionPlanResponse>> GetAll(CancellationToken ct)
    {
        return await _dbContext.SubscriptionPlans
                               .Select(s => new GetSubscriptionPlanResponse
                               (
                                  s.Id.ToString(),
                                  s.Name,
                                  s.Description,
                                  s.Price,
                                  s.DurationDays

                               )).ToListAsync(ct);
    }
}
