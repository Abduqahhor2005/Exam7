namespace Infrastructure.Models;

public class UsersWithTasks
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}