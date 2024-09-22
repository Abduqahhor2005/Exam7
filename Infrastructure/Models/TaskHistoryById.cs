namespace Infrastructure.Models;

public class TaskHistoryById
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime Changedat { get; set; }
}