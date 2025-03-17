namespace Thayen.WebPlanner.API.Model;

public record TaskView : IWebView
{
    public required long Id { get; set; }
    public required string? Name { get; set; }
    public int Priority { get; set; } = 0;
}