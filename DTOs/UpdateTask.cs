namespace TaskManger.DTOs
{
    public class UpdateTask
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsCompleted { get; set; }
        public string? UserName { get; set; }
        public int? Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
