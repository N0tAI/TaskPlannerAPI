using Thayen.WebPlanner.Data.Models;

namespace Thayen.WebPlanner.Data.Repositories;

public class CategoryRepository(PlannerDatabaseContext ctx) : Repository(ctx)
{
    public IEnumerable<CategoryModel> GetAllCategories()
    {
        return _context.Categories.AsEnumerable();
    }
}