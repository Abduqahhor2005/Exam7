using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface ITaskAttachmentRepository
{
    Task<IEnumerable<TaskAttachment>> GetAll();
    Task<TaskAttachment?> GetById(Guid id);
    Task<bool> CreateAsync(TaskAttachment taskAttachment);
    Task<bool> UpdateAsync(TaskAttachment taskAttachment);
    Task<bool> DeleteAsync(Guid id);
}