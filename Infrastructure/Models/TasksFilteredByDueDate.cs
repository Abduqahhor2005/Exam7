namespace Infrastructure.Models;

public class TasksFilteredByDueDate
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime DueDate { get; set; }
}