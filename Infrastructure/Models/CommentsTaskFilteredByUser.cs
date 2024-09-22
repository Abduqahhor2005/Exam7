namespace Infrastructure.Models;

public class CommentsTaskFilteredByUser
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}