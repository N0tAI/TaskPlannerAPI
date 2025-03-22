using Microsoft.EntityFrameworkCore;
using Thayen.WebPlanner.Data.Models;

namespace Thayen.WebPlanner.Data
{
    public class PlannerDatabaseContext : DbContext
	{
        public virtual DbSet<CategoryModel> Categories { get; set; }
        public virtual DbSet<TaskModel> Tasks { get; set; }
        public virtual DbSet<MilestoneModel> Milestones { get; set; }

        public PlannerDatabaseContext(DbContextOptions<PlannerDatabaseContext> options) : base(options)
        {
                
        }
    }
}
