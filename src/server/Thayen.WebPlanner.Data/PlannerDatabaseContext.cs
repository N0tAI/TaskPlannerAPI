using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Thayen.WebPlanner.Data.Models;

namespace Thayen.WebPlanner.Data
{
    public class PlannerDatabaseContext : DbContext
	{
        public PlannerDatabaseContext(DbContextOptions<PlannerDatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure IdType to Guid conversion for all properties
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(IdType))
                    {
                        property.SetValueConverter(new ValueConverter<IdType, Guid>(
                            id => id.Value,
                            guid => new IdType(guid)
                        ));
                    }
                }
            }
        }
    }
}
