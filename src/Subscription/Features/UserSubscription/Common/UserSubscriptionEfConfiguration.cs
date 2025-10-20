using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscription.Features.SubscriptionPlan.Common;
using Subscription.Infrastructure.Persistence.Context;

namespace Subscription.Features.UserSubscription.Common;

public class UserSubscriptionEfConfiguration : IEntityTypeConfiguration<UserSubscription>
{
    public void Configure(EntityTypeBuilder<UserSubscription> builder)
    {
        builder.ToTable(SubscriptionDbContextSchema.UserSubscription.TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
                  .ValueGeneratedNever()
                  .HasConversion(id => id.Value,
                                  value => UserSubscriptionId.Create(value));

        builder.Property(x => x.UserId)
                  .IsRequired(true)
                  .ValueGeneratedNever()
                  .HasConversion(id => id.Value,
                                 value => UserId.Create(value));


        builder.Property(x => x.SubscriptionPlanId)
                  .IsRequired(true)
                  .ValueGeneratedNever()
                  .HasConversion(id => id.Value,
                                 value => SubscriptionPlanId.Create(value));


        builder.Property(x => x.StartDate)
                .IsRequired(true);


        builder.Property(x => x.EndDate)
                 .IsRequired(true);


        builder.Property(x => x.CreatedAt)
                .IsRequired(true);


        builder.Property(x => x.IsActive)
                 .IsRequired(true);
    }
}
