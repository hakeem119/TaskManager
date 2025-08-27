using Microsoft.EntityFrameworkCore;
using TaskManger.Models;

namespace TaskManger.Repositories
{
    public class TaskRepo:ITaskRepo
    {
        private readonly AppDbContext _db;
        public TaskRepo(AppDbContext db) => _db = db;

        public async Task AddAsync(Items item)
        {
            await _db.Tasks.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task<int> CountAsync(string? search = null, int? priority = null, bool? isCompleted = null)
        {
            var q = FilteredQuery(search, priority, isCompleted);
            return await q.CountAsync();
        }

        public async Task DeleteAsync(Items item)
        {
            _db.Tasks.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Items>> GetAllAsync(string? search = null, int? priority = null, bool? isCompleted = null, int page = 1, int pageSize = 20)
        {
            var q = FilteredQuery(search, priority, isCompleted)
                .OrderBy(t => t.DueDate ?? DateTime.MaxValue)
                .ThenByDescending(t => t.Priority)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return await q.ToListAsync();
        }

        public async Task<Items?> GetByIdAsync(Guid id)
        {
            return await _db.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(Items item)
        {
            _db.Tasks.Update(item);
            await _db.SaveChangesAsync();
        }

        private IQueryable<Items> FilteredQuery(string? search, int? priority, bool? isCompleted)
        {
            var q = _db.Tasks.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var s = search.Trim().ToLower();
                q = q.Where(t => t.Title.ToLower().Contains(s) || (t.Description != null && t.Description.ToLower().Contains(s)) || (t.UserName != null && t.UserName.ToLower().Contains(s)));
            }

            if (priority.HasValue)
            {
                q = q.Where(t => (int)t.Priority == priority.Value);
            }

            if (isCompleted.HasValue)
            {
                q = q.Where(t => t.IsCompleted == isCompleted.Value);
            }

            return q;
        }
    }
}
