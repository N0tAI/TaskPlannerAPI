namespace Thayen.WebPlanner.Data.Models;

public record class MilestoneModel : IModel
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public IEnumerable<CategoryModel> Categories { get; set; } = [];
    public IEnumerable<MilestoneModel> Milestones { get; set; } = [];
    public IEnumerable<TaskModel> Tasks { get; set; } = [];
}