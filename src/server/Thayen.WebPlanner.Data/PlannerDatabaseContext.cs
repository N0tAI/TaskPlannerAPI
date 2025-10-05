using Microsoft.EntityFrameworkCore;

namespace Thayen.WebPlanner.Data
{
    public class PlannerDatabaseContext : DbContext
	{
        public PlannerDatabaseContext(DbContextOptions<PlannerDatabaseContext> options) : base(options)
        {

        }
    }
}
