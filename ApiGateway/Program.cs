using CatalogService;
using OrderService;
using InventoryService;
using UserService;

var builder = WebApplication.CreateBuilder(args);

// Register gRPC clients pointing to the respective service URLs (HTTPS)
builder.Services.AddGrpcClient<Catalog.CatalogClient>(o => { o.Address = new Uri("https://localhost:5011"); });
builder.Services.AddGrpcClient<Order.OrderClient>(o => { o.Address = new Uri("https://localhost:5021"); });
builder.Services.AddGrpcClient<Inventory.InventoryClient>(o => { o.Address = new Uri("https://localhost:5031"); });
builder.Services.AddGrpcClient<User.UserClient>(o => { o.Address = new Uri("https://localhost:5041"); });

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/catalog/{id}", async (int id, Catalog.CatalogClient client) =>
{
    var reply = await client.GetItemAsync(new GetItemRequest { Id = id });
    return Results.Ok(new { reply.Id, reply.Name, reply.Price });
});

app.MapPost("/order", async (PlaceOrderRequest req, Order.OrderClient client) =>
{
    var reply = await client.PlaceOrderAsync(req);
    return Results.Ok(new { reply.Success, reply.Message });
});

app.MapGet("/inventory/{itemId}", async (int itemId, Inventory.InventoryClient client) =>
{
    var reply = await client.CheckStockAsync(new CheckStockRequest { ItemId = itemId });
    return Results.Ok(new { reply.InStock });
});

app.MapGet("/user/{id}", async (int id, User.UserClient client) =>
{
    var reply = await client.GetUserAsync(new GetUserRequest { Id = id });
    return Results.Ok(new { reply.Id, reply.Username });
});

app.Run();
