namespace Infrastructure.Models;

public class TaskAttachmentsWithUserInformation
{
    public Guid Id { get; set; }
    public string FilePath { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string UserName { get; set; } = null!;
}