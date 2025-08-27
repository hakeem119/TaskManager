using static TaskManger.Models.@enum;

namespace TaskManger.Models
{
    public class Items
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public Priority Priority { get; set; } = Priority.Medium;
        public DateTime? DueDate { get; set; }
        public string? UserName { get; set; }  
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
