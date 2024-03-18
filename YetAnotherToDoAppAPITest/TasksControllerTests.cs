using Microsoft.AspNetCore.Mvc;
using Moq;
using YetAnotherTodoApp.Controllers;
using YetAnotherTodoApp.Services;
using YetAnotherToDoAppAPITest.Fixtures;
using Task = YetAnotherTodoApp.Task;

namespace YetAnotherToDoAppAPITest;

public class TasksControllerTests
{
    [Fact]
    public void GetAllReturnsValidAmountOfTasks()
    {
        var mockTasksService = new Mock<ITasksService>();
        mockTasksService.Setup(service => service.GetAll())
            .Returns(TasksFixtures.GetTasks());
        var controller = new TasksController(mockTasksService.Object);

        var tasks = controller.GetAll().Value;
        Assert.NotNull(tasks);
        Assert.Equal(3, tasks.Count);
    }

    [Fact]
    public void GetByExistingIdReturnsATask()
    {
        var mockTasksService = new Mock<ITasksService>();
        mockTasksService.Setup(service => service.GetById(It.IsAny<int>()))
            .Returns(TasksFixtures.GetTasks()[0]);
        var controller = new TasksController(mockTasksService.Object);

        var task = controller.GetById(1).Value;
        Assert.NotNull(task);
    }

    [Fact]
    public void GetByNonexistantIdReturnsNotFound()
    {
        var mockTasksService = new Mock<ITasksService>();
        mockTasksService.Setup(service => service.GetById(It.IsAny<int>()))
            .Returns(It.IsAny<Task>);
        var controller = new TasksController(mockTasksService.Object);

        var result = controller.GetById(5).Result as NotFoundResult;
        Assert.NotNull(result);
        Assert.Equal(404, result.StatusCode);
    }

    [Fact]
    public void CreateWithValidInputReturnCreatedAt()
    {
        var mockTasksService = new Mock<ITasksService>();
        mockTasksService.Setup(service => service.Create(It.IsAny<Task>()));
        var controller = new TasksController(mockTasksService.Object);

        var task = TasksFixtures.GetValidTask();
        var result = controller.Create(task) as ObjectResult;
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
    }

    [Fact]
    public void CreateWithInvalidInputReturnBadRequest()
    {
        var mockTasksService = new Mock<ITasksService>();
        mockTasksService.Setup(service => service.Create(It.IsAny<Task>()));
        var controller = new TasksController(mockTasksService.Object);

        var task = TasksFixtures.GetCompletedTask();
        var result = controller.Create(task) as ObjectResult;
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void UpdateWithValidInputReturnsNoContent()
    {
        var task = TasksFixtures.GetValidTask();
        var mockTasksService = new Mock<ITasksService>();
        mockTasksService.Setup(service => service.GetById(It.IsAny<int>()))
            .Returns(task);
        mockTasksService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<Task>()));
        var controller = new TasksController(mockTasksService.Object);

        task.IsCompleted = true;
        task.Id = 1;
        var result = controller.Update(1, task) as NoContentResult;
        Assert.NotNull(result);
        Assert.Equal(204, result.StatusCode);
    }

    [Fact]
    public void UpdateWithMismatchingIdsReturnsBadRequest()
    {
        var mockTasksService = new Mock<ITasksService>();
        mockTasksService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<Task>()));
        var controller = new TasksController(mockTasksService.Object);

        var task = TasksFixtures.GetValidTask();
        task.IsCompleted = true;
        task.Id = 1;
        var result = controller.Update(2, task) as ObjectResult;
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
    }
    
    [Fact]
    public void UpdateNonexistantTaskReturnNotFound()
    {
        var mockTasksService = new Mock<ITasksService>();
        mockTasksService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<Task>()));
        var controller = new TasksController(mockTasksService.Object);

        var updatedTask = TasksFixtures.GetValidTask();
        updatedTask.Id = 2;
        updatedTask.IsCompleted = true;

        var result = controller.Update(2, updatedTask) as NotFoundResult;
        Assert.NotNull(result);
        Assert.Equal(404, result.StatusCode);
    }
    
    [Fact]
    public void DeleteExistingTaskReturnsNoContent()
    {
        var task = TasksFixtures.GetValidTask();
        task.Id = 1;
        var mockTasksService = new Mock<ITasksService>();
        mockTasksService.Setup(service => service.GetById(It.IsAny<int>()))
            .Returns(task);
        mockTasksService.Setup(service => service.Delete(It.IsAny<int>()));
        var controller = new TasksController(mockTasksService.Object);
 
        var result = controller.Delete(1) as NoContentResult;
        Assert.NotNull(result);
        Assert.Equal(204, result.StatusCode);
    }

    [Fact]
    public void DeleteNonexistantTaskReturnNotFound()
    {
        var mockTasksService = new Mock<ITasksService>();
        mockTasksService.Setup(service => service.Delete(It.IsAny<int>()));
        var controller = new TasksController(mockTasksService.Object);
 
        var result = controller.Delete(1) as NotFoundResult;
        Assert.NotNull(result);
        Assert.Equal(404, result.StatusCode);
    }
}