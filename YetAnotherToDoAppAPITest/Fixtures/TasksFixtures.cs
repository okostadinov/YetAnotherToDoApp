using Task = YetAnotherTodoApp.Task;

namespace YetAnotherToDoAppAPITest.Fixtures;

public class TasksFixtures
{
    public static List<Task> GetTasks() => new() {
        new() { Id = 1, Title = "task A" },
        new() { Id = 2, Title = "task B", IsPrioritized = true, DueDate = new(2025, 12, 12) },
        new() { Id = 3, Title = "task C", IsPrioritized = true, DueDate = new(2024, 12, 12) }
    };

    public static Task GetValidTask() => new()
    {
        Title = "test task",
        Description = "lorem ipsum",
        IsPrioritized = true,
        DueDate = new(2025, 12, 12)
    };

    public static Task GetCompletedTask() => new()
    {
        Title = "test task",
        Description = "lorem ipsum",
        IsPrioritized = true,
        DueDate = new(2025, 12, 12),
        IsCompleted = true
    };
}