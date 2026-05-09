namespace TODOAPI.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public required  string Title { get; set; }
        public required  string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public required  string Priority { get; set; } // Low, Medium, High
    }
}
