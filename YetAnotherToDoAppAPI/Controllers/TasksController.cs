using Microsoft.AspNetCore.Mvc;
using YetAnotherTodoApp.Services;

namespace YetAnotherTodoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITasksService _service;
    public TasksController(ITasksService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Task>> GetAll() => _service.GetAll();

    [HttpGet("completed")]
    public ActionResult<List<Task>> GetCompleted() => _service.GetCompleted();

    [HttpGet("prioritized")]
    public ActionResult<List<Task>> GetPrioritized() => _service.GetPrioritized();

    [HttpGet("{id}")]
    public ActionResult<Task> GetById(int id)
    {
        var task = _service.GetById(id);

        if (task is null) return NotFound();

        return task;
    }

    [HttpPost]
    public IActionResult Create(Task task)
    {
        if (task.IsCompleted)
            return BadRequest("Cannot create a completed task");

        _service.Create(task);

        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Task task)
    {
        if (id != task.Id)
            return BadRequest("Task ID does not match target");

        var taskToUpdate = _service.GetById(id);
        if (taskToUpdate is null) return NotFound();

        _service.Update(id, task);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var task = _service.GetById(id);

        if (task is null) return NotFound();

        _service.Delete(id);
        return NoContent();
    }
}