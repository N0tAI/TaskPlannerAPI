namespace Planner.Data.Models;

public partial class Todo
{
    public Guid TodoId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Priority { get; set; }

    public DateTime? CompletionDate { get; set; }

    public Guid? ParentTodoId { get; set; }

    public virtual ICollection<Todo> InverseParentTodo { get; set; } = new List<Todo>();

    public virtual Todo? ParentTodo { get; set; }

    public virtual ICollection<TodoCategory> TodoCategories { get; set; } = new List<TodoCategory>();
}
