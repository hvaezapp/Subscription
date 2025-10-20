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
        // solution 1 based on bussines
        await DeactiveAllUserSubscriptions(userId, ct);

        // solution 2 based on bussines
        #region
        //var activeSubscription = await FindActiveSubscription(userId, ct);
        //if (activeSubscription is not null)
        //    UserHasActiveSubscriptionException.Throw(activeSubscription.SubscriptionPlanId, activeSubscription.SubscriptionPlan.Name);
        #endregion

        var subscriptionPlan = await _subscriptionPlanService.GetById(subscriptionPlanId, ct);

        var newUserSubscription = UserSubscription.Create(userId, subscriptionPlanId, subscriptionPlan.DurationDays);

        _dbContext.UserSubscriptions.Add(newUserSubscription);
        await _dbContext.SaveChangesAsync(ct);

        return newUserSubscription.Id;
    }


    // solution 1 based on bussines
    private async Task DeactiveAllUserSubscriptions(UserId userId, CancellationToken ct)
    {
        await _dbContext.UserSubscriptions
                            .Where(sub => sub.IsActive && sub.UserId == userId)
                            .ExecuteUpdateAsync(u => u
                                 .SetProperty(sub => sub.IsActive, false)
                            );
    }

    // solution 2 based on bussines

    //private async Task<UserSubscription?> FindActiveSubscription(UserId userId, CancellationToken ct)
    //{
    //    return await _dbContext.UserSubscriptions
    //                           .Include(a => a.SubscriptionPlan)
    //                           .FirstOrDefaultAsync(a => a.UserId == userId && a.IsActive, ct);
    //}
}
