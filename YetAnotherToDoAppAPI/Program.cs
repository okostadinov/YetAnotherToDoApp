using YetAnotherTodoApp.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<ITasksService, InMemoryTasksService>();
}

var app = builder.Build();
{
    app.MapControllers();
}

app.Run();
