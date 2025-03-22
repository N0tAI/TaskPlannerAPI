using Microsoft.Extensions.Logging;

namespace Thayen.WebPlanner.Data
{
    public abstract class Repository(PlannerDatabaseContext ctx, ILoggerFactory logger)
    {
        protected readonly ILoggerFactory _logFactory = logger;
        protected readonly PlannerDatabaseContext _context = ctx;
        
    }
}
