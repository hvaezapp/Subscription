using Microsoft.EntityFrameworkCore;
using Subscription.Features.SubscriptionPlan.Common;
using Subscription.Features.UserSubscription.Common;

namespace Subscription.Infrastructure.Persistence.Context;

public class SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<SubscriptionPlan> SubscriptionPlans => Set<SubscriptionPlan>();
    public DbSet<UserSubscription> UserSubscriptions => Set<UserSubscription>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SubscriptionDbContextSchema.DefaultSchema);

        var assembly = typeof(IAssemblyMarker).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }
}