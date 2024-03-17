namespace YetAnotherTodoApp.Services;

public class InMemoryTaskService : ITasksService
{
    private static List<Task> _tasks = default!;
    private static int _nextId;

    public InMemoryTaskService()
    {
        _tasks = [
            new Task {Id = 1, Title = "mock task A", Description = "this is a test task", DueDate = new(2025, 01, 01) },
            new Task {Id = 2, Title = "mock task B", DueDate = new(2024, 12, 31) },
            new Task {Id = 3, Title = "prioritized task A", IsPrioritized = true, DueDate = new(2024, 06, 06) },
            new Task {Id = 4, Title = "prioritized task B", IsPrioritized = true, DueDate = new(2024, 05, 05) },
        ];
        _nextId = _tasks.Count + 1;
    }

    public List<Task> GetAll() => _tasks;

    public List<Task> GetCompleted() =>
        _tasks.Where(t => t.IsCompleted).ToList();

    public List<Task> GetPrioritized() =>
        _tasks.Where(t => t.IsPrioritized).OrderBy(t => t.DueDate).ToList();

    public Task? GetById(int id) =>
        _tasks.SingleOrDefault(t => t.Id == id);

    public void Create(Task task)
    {
        task.Id = _nextId++;
        _tasks.Add(task);
    }

    public void Update(int id, Task task)
    {
        var taskIndex = _tasks.FindIndex(t => t.Id == id);

        if (taskIndex != -1)
            _tasks[taskIndex] = task;
    }

    public void Delete(int id)
    {
        var task = GetById(id);

        if (task is not null)
            _tasks.Remove(task);
    }
}