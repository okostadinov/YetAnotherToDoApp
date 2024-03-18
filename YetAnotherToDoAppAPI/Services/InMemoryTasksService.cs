namespace YetAnotherTodoApp.Services;

public class InMemoryTasksService : ITasksService
{
    private static readonly List<Task> _tasks = [];
    private static int _nextId = _tasks.Count + 1;

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