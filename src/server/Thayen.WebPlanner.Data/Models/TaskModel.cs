namespace Thayen.WebPlanner.Data.Models;

public record class TaskModel : IModel
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public int Priority { get; set; } = 0;
    public IEnumerable<CategoryModel> Categories { get; set; } = [];
    public IEnumerable<MilestoneModel> Milestones { get; set; } = [];
    public IEnumerable<TaskModel> SubTasks { get; set; } = [];
}