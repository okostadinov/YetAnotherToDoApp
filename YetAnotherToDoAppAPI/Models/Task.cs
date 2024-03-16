using System.ComponentModel.DataAnnotations;

namespace YetAnotherTodoApp;

public class Task
{
    public int Id { get; set; }

    [Required]
    [MinLength(1)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsCompleted { get; set; } = false;

    public bool IsPrioritized { get; set; } = false;

    public DateTime CreatedOn { get; } = DateTime.Now;

    [Required]
    public DateTime DueDate { get; set; }
}
