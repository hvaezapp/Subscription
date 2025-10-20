using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Subscription.Infrastructure.Persistence.Context;

namespace Subscription.Configuration;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SubscriptionDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(SubscriptionDbContextSchema.DefaultConnectionStringName));
        });

        return services;
    }

    public static IServiceCollection ConfigureValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

        return services;
    }

}
