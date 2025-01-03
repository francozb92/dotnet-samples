// See https://aka.ms/new-console-template for more information
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;


// Console.WriteLine("This is a sample project about feature switches in dotnet 9.0 runtime");
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

if(APIFeature.OnlyTodo){

app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound());

app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});
}

if(APIFeature.OnlyCompleted){

app.MapGet("/todoitems/complete", async (TodoDb db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync());
}

app.Run();


// //Base example
public class Feature
{
    [FeatureSwitchDefinition("Feature.IsSupported")]
    internal static bool IsSupported => AppContext.TryGetSwitch("Feature.IsSupported", out bool isEnabled) ? isEnabled : true;
    internal static void Implementation() => Console.WriteLine("Hello from feature enabled!");
}

//API example using feature switches 
public class APIFeature
{
    [FeatureSwitchDefinition("APIFeature.OnlyCompleted")]
    internal static bool OnlyCompleted => AppContext.TryGetSwitch("APIFeature.OnlyCompleted", out bool onlyCompleted) ? onlyCompleted : true;
    [FeatureSwitchDefinition("APIFeature.OnlyTodo")]
    internal static bool OnlyTodo => AppContext.TryGetSwitch("APIFeature.OnlyTodo", out bool onlyTodo) ? onlyTodo : true;
}





