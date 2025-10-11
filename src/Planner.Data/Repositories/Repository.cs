using Microsoft.Extensions.Logging;

namespace Thayen.WebPlanner.Data
{
    public abstract class Repository(PlannerContext ctx, ILoggerFactory logger)
    {
        protected readonly ILoggerFactory _logFactory = logger;
        protected readonly PlannerContext _context = ctx;

    }
}
