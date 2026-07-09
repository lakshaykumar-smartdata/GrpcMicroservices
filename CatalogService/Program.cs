var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/catalog/{id:int}", (int id) =>
{
    return Results.Ok(new { id = id, name = $"Test Item {id}", price = 9.99 });
});

app.Run();
