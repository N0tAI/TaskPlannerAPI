using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Planner.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection collection, string connectionString)
    {
        return collection.AddDbContextPool<PlannerContext>(options =>
            options.UseNpgsql(connectionString)
                   .UseSnakeCaseNamingConvention())
               .AddScoped<IUnitOfWork, UnitOfWork>();

    }
}