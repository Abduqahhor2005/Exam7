using Infrastructure.Enum;

namespace Infrastructure.Models;

public class TasksByPriority
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Priorities Priority { get; set; }
}