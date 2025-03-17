using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Thayen.WebPlanner.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection collection, string connectionString)
        {
            return collection.AddDbContextPool<PlannerDatabaseContext>(options => options.UseNpgsql(connectionString));
        }
    }
}
