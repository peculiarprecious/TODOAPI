using System.ComponentModel.DataAnnotations;

namespace TODOAPI.DTOs
{
    public class UpdateTodoDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3,
           ErrorMessage = "Title must be between 3 and 100 characters")]
      
        public required string Title { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public required string Description { get; set; }

        public bool IsCompleted { get; set; } = false;

        public DateTime? DueDate { get; set; }

        [RegularExpression("Low|Medium|High",
            ErrorMessage = "Priority must be Low, Medium or High")]
        public string Priority { get; set; } = "Medium";


        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            // Title cannot be only whitespace
            if (string.IsNullOrWhiteSpace(Title))
            {
                yield return new ValidationResult(
                    "Title cannot be empty contain only whitespace",
                    new[] { nameof(Title) }
                );
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                yield return new ValidationResult(

                    "Description cannot be empty or contain only whitespace",
                    new[] { nameof(Description) });
            }

            // DueDate cannot be in the past
            if (DueDate.HasValue && DueDate.Value < DateTime.Now)
            {
                yield return new ValidationResult(
                    "DueDate cannot be in the past",
                    new[] { nameof(DueDate) }
                );
            }
        }


    }
}
