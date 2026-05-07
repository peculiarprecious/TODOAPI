using System.ComponentModel.DataAnnotations;

namespace TODOAPI.DTOs
{
    public class CreateTodoDto
    {
        
    [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters")]
        public required string Title { get; set; }

        [StringLength(500)]
        public required string Description { get; set; }

        public DateTime? DueDate { get; set; }

        [RegularExpression("Low|Medium|High", ErrorMessage = "Priority must be Low, Medium, or High")]
        public string Priority { get; set; } = "Medium";
    }
}

