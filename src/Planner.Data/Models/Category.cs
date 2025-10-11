using System;
using System.Collections.Generic;

namespace Thayen.WebPlanner.Data.Models;

public partial class Category
{
    public Guid CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TodoCategory> TodoCategories { get; set; } = new List<TodoCategory>();
}
