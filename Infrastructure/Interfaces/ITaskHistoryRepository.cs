using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface ITaskHistoryRepository
{
    Task<IEnumerable<TaskHistory>> GetAll();
    Task<TaskHistory?> GetById(Guid id);
    Task<bool> CreateAsync(TaskHistory taskHistory);
    Task<bool> UpdateAsync(TaskHistory taskHistory);
    Task<bool> DeleteAsync(Guid id);
}