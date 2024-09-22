namespace Infrastructure.Models;

public class TasksOrderedByDueDate
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DueDate { get; set; }
}