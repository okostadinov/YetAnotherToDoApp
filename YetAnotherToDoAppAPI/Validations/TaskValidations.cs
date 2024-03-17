using System.ComponentModel.DataAnnotations;

namespace YetAnotherTodoApp.Validations;

public class TaskDueDateAttribute : ValidationAttribute
{
    private readonly DateOnly _minimumDueDate = DateOnly.FromDateTime(DateTime.Now);

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null) return ValidationResult.Success;

        if (!DateTime.TryParse(value.ToString(), out DateTime dueDate))
            return new ValidationResult("Invalid due date input");

        if (DateOnly.FromDateTime(dueDate) < _minimumDueDate)
            return new ValidationResult("Cannot have a due date in the past");

        return ValidationResult.Success;
    }
}
