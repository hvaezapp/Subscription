using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscription.Infrastructure.Persistence.Context;

namespace Subscription.Features.SubscriptionPlan.Common;

public class SubscriptionPlanEfConfiguration : IEntityTypeConfiguration<SubscriptionPlan>
{
    public void Configure(EntityTypeBuilder<SubscriptionPlan> builder)
    {
        builder.ToTable(SubscriptionDbContextSchema.SubscriptionPlan.TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
                  .ValueGeneratedNever()
                  .HasConversion(id => id.Value,
                                  value => SubscriptionPlanId.Create(value));

        builder.Property(x => x.Name)
                  .IsRequired(true)
                  .HasMaxLength(50);


        builder.Property(x => x.Description)
                    .IsRequired(true)
                    .HasMaxLength(300);


        builder.Property(x => x.Price)
                    .IsRequired(true)
                    .HasColumnType(SubscriptionDbContextSchema.DefaultDecimalColumnType);


        builder.Property(x => x.DurationDays)
                  .IsRequired(true);


        builder.HasMany(x => x.UserSubscriptions)
               .WithOne(x => x.SubscriptionPlan)
               .HasForeignKey(x => x.SubscriptionPlanId);

    }
}
