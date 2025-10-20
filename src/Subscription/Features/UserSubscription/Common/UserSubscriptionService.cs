using Microsoft.EntityFrameworkCore;
using Subscription.Features.SubscriptionPlan.Common;
using Subscription.Infrastructure.Persistence.Context;

namespace Subscription.Features.UserSubscription.Common;

public class UserSubscriptionService(SubscriptionDbContext dbContext, SubscriptionPlanService subscriptionPlanService)
{
    public readonly SubscriptionPlanService _subscriptionPlanService = subscriptionPlanService;
    private readonly SubscriptionDbContext _dbContext = dbContext;

    public async Task<UserSubscriptionId> Create(UserId userId, SubscriptionPlanId subscriptionPlanId, CancellationToken ct)
    {
        // check user has active subscription
        var activeSubscription = await FindActiveSubscription(userId, ct);
        if (activeSubscription is not null)
            UserHasActiveSubscriptionException.Throw(activeSubscription.SubscriptionPlanId, activeSubscription.SubscriptionPlan.Name);

        // get current subscription info
        var subscriptionPlan = await _subscriptionPlanService.GetById(subscriptionPlanId, ct);

        var newUserSubscription = UserSubscription.Create(userId, subscriptionPlanId, subscriptionPlan.DurationDays);

        _dbContext.UserSubscriptions.Add(newUserSubscription);
        await _dbContext.SaveChangesAsync(ct);

        return newUserSubscription.Id;
    }


    private async Task<UserSubscription?> FindActiveSubscription(UserId userId, CancellationToken ct)
    {
        return await _dbContext.UserSubscriptions
                               .Include(a => a.SubscriptionPlan)
                               .FirstOrDefaultAsync(a => a.UserId == userId && a.IsActive, ct);
    }
}
