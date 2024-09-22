using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAll();
    Task<Category?> GetById(Guid id);
    Task<bool> CreateAsync(Category category);
    Task<bool> UpdateAsync(Category category);
    Task<bool> DeleteAsync(Guid id);
}