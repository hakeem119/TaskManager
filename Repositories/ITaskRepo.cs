using TaskManger.Models;

namespace TaskManger.Repositories
{
    public interface ITaskRepo
    {
        Task<Items?> GetByIdAsync(Guid id);
        Task<IEnumerable<Items>> GetAllAsync(string? search = null, int? priority = null, bool? isCompleted = null, int page = 1, int pageSize = 20);
        Task AddAsync(Items item);
        Task UpdateAsync(Items item);
        Task DeleteAsync(Items item);
        Task<int> CountAsync(string? search = null, int? priority = null, bool? isCompleted = null);
    }
}
