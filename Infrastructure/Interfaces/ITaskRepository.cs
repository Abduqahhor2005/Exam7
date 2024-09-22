using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<Tasks>> GetAll();
    Task<Tasks?> GetById(Guid id);
    Task<bool> CreateAsync(Tasks task);
    Task<bool> UpdateAsync(Tasks task);
    Task<bool> DeleteAsync(Guid id);
}