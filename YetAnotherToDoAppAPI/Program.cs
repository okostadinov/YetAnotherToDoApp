using YetAnotherTodoApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITasksService>(new InMemoryTaskService());

var app = builder.Build();

app.Run();
