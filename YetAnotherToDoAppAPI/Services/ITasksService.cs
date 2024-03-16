namespace YetAnotherTodoApp.Services;

public interface ITasksService
{
    public List<Task> GetAll();
    public List<Task> GetCompleted();
    public List<Task> GetPrioritized();
    public Task? GetById(int id);
    public void Create(Task task);
    public void Update(int id, Task task);
    public void Delete(int id);
}