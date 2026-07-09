var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/order", (OrderRequest req) =>
{
    return Results.Ok(new { success = true, orderId = Random.Shared.Next(10000, 99999), message = $"Placed order for {req.Quantity} of item {req.ItemId}" });
});

app.Run();

public class OrderRequest
{
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}
