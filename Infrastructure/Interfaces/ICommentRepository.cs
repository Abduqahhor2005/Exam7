using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetAll();
    Task<Comment?> GetById(Guid id);
    Task<bool> CreateAsync(Comment comment);
    Task<bool> UpdateAsync(Comment comment);
    Task<bool> DeleteAsync(Guid id);
}