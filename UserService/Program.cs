var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/user/{id:int}", (int id) =>
{
    return Results.Ok(new { id = id, name = $"User {id}", status = "Active" });
});

app.Run();
