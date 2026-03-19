namespace Planner.Data.Models;

public partial class Category
{
    public Guid CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TodoCategory> TodoCategories { get; set; } = new List<TodoCategory>();
}
