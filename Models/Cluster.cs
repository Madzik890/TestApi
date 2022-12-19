namespace JrAPI.Models;

public record Cluster
{
    public string Name { get; set; }
    public string Component { get; set; }
    public string[] Files { get; set; }
    public string Icon { get; set; }
}