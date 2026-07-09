var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/inventory/{id:int}", (int id) =>
{
    return Results.Ok(new { inStock = true, quantity = Random.Shared.Next(10, 100), message = $"Inventory checked for item {id}" });
});

app.Run();
