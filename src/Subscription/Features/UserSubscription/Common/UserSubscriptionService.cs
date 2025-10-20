using Microsoft.EntityFrameworkCore;
using Subscription.Features.SubscriptionPlan.Common;
using Subscription.Features.SubscriptionPlan.GetAll;
using Subscription.Features.UserSubscription.GetUserSubscription;
using Subscription.Infrastructure.Persistence.Context;

namespace Subscription.Features.UserSubscription.Common;

public class UserSubscriptionService(SubscriptionDbContext dbContext, SubscriptionPlanService subscriptionPlanService)
{
    public readonly SubscriptionPlanService _subscriptionPlanService = subscriptionPlanService;
    private readonly SubscriptionDbContext _dbContext = dbContext;

    public async Task Activate(UserId userId, SubscriptionPlanId subscriptionPlanId, CancellationToken ct)
    {
        // Check whether the user exists, assuming the UserId comes from user input


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

    }

    public async Task Deactivate(UserId userId, SubscriptionPlanId subscriptionPlanId, CancellationToken ct)
    {
        var userSubscription = await _dbContext.UserSubscriptions
                                               .FirstOrDefaultAsync(a => a.UserId == userId &&
                                                a.SubscriptionPlanId == subscriptionPlanId &&
                                                a.IsActive, ct);

        if (userSubscription is null)
            UserSubscriptionNotFoundException.Throw();


        userSubscription.Deactive();
        await _dbContext.SaveChangesAsync(ct);
    }


    public async Task<IEnumerable<GetUserSubscriptionResponse>> GetActiveUserSubscriptionsByUserId(UserId userId, CancellationToken ct)
    {

        return await _dbContext.UserSubscriptions
                                .AsNoTracking()
                                .Include(s => s.SubscriptionPlan)
                                .Where(a => a.UserId == userId && a.IsActive)
                                .Select(s => new GetUserSubscriptionResponse
                                (
                                     s.Id.ToString(),
                                     s.SubscriptionPlanId.ToString(),
                                     s.SubscriptionPlan.Name,
                                     s.SubscriptionPlan.Description,
                                     s.SubscriptionPlan.Price,
                                     s.SubscriptionPlan.DurationDays,
                                     s.StartDate,
                                     s.EndDate,
                                     s.CreatedAt,
                                     s.IsActive

                                )).ToListAsync(ct);
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
    #region 
    //private async Task<UserSubscription?> FindActiveSubscription(UserId userId, CancellationToken ct)
    //{
    //    return await _dbContext.UserSubscriptions
    //                           .Include(a => a.SubscriptionPlan)
    //                           .FirstOrDefaultAsync(a => a.UserId == userId && a.IsActive, ct);
    //}
    #endregion
}
