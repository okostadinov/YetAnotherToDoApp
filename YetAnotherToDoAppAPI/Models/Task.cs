using System.ComponentModel.DataAnnotations;
using YetAnotherTodoApp.Validations;

namespace YetAnotherTodoApp;

public class Task
{
    public int Id { get; set; }

    [Required, MinLength(4), MaxLength(25)]
    public string Title { get; set; } = null!;

    [MaxLength(250)]
    public string? Description { get; set; }

    public bool IsCompleted { get; set; } = false;

    public bool IsPrioritized { get; set; } = false;

    public DateOnly CreatedOn { get; } = DateOnly.FromDateTime(DateTime.Now);

    [DataType(DataType.Date), TaskDueDate]
    public DateOnly DueDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}
