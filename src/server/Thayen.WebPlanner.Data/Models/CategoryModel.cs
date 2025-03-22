namespace Thayen.WebPlanner.Data.Models;

public record class CategoryModel : IModel
{   
    public long? Id { get; set; }
    public string Name { get; set; } = string.Empty;
}