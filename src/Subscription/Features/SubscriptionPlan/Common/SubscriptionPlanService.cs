using Microsoft.EntityFrameworkCore;
using Subscription.Features.SubscriptionPlan.GetAll;
using Subscription.Infrastructure.Persistence.Context;

namespace Subscription.Features.SubscriptionPlan.Common;

public class SubscriptionPlanService(SubscriptionDbContext dbContext)
{
    private readonly SubscriptionDbContext _dbContext = dbContext;

    public async Task<SubscriptionPlanId> Create(string name, string description,
                                                      decimal price, int durationDays,
                                                      CancellationToken ct)
    {
        var subscriptionPlan = await FindSubscriptionPlanBasedDurationDays(durationDays , ct);
        if (subscriptionPlan is not null)
            SubscriptionPlanExistsBeforeException.Throw(subscriptionPlan.Name);

        var newSubscriptionPlan = SubscriptionPlan.Create(name, description, price, durationDays);

        _dbContext.SubscriptionPlans.Add(newSubscriptionPlan);
        await _dbContext.SaveChangesAsync(ct);

        return newSubscriptionPlan.Id;
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

    public async Task<SubscriptionPlan> GetById(SubscriptionPlanId subscriptionPlanId, CancellationToken ct)
    {
        var subscriptionPlan =  await _dbContext.SubscriptionPlans.FirstOrDefaultAsync(s => s.Id == subscriptionPlanId, ct);
        if (subscriptionPlan is null)
        {
            SubscriptionPlanNotFoundException.Throw(subscriptionPlanId);
        }
        return subscriptionPlan;
    }


    private async Task<SubscriptionPlan?> FindSubscriptionPlanBasedDurationDays(int durationDays, CancellationToken ct)
    {
        return await _dbContext.SubscriptionPlans.FirstOrDefaultAsync(a => a.DurationDays == durationDays, ct);
    }

}
