using System;
using System.Collections.Generic;

namespace Thayen.WebPlanner.Data.Models;

public partial class TodoCategory
{
    public Guid TodoId { get; set; }

    public Guid CategoryId { get; set; }

    public int CategoryZIndex { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Todo Todo { get; set; } = null!;
}
