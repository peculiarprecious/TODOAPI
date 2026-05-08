using System.ComponentModel.DataAnnotations;

namespace TODOAPI.DTOs
{
    public class UpdateTodoDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3)]
        public required string Title { get; set; }

        [StringLength(500)]
        public required string Description { get; set; }

        public bool IsCompleted { get; set; } = false;

        public DateTime? DueDate { get; set; }

        [RegularExpression("Low|Medium|High")]
        public string Priority { get; set; } = "Medium";
    }
}
