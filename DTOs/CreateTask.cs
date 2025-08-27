namespace TaskManger.DTOs
{
    public class CreateTask
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string? UserName { get; set; }
        public int Priority { get; set; } = 1;
        public DateTime? DueDate { get; set; }
    }
}
