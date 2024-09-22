namespace Infrastructure.Models;

public class TasksWithUserAndCategory
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Name { get; set; } = null!;
}