var builder = WebApplication.CreateBuilder(args);

// Add YARP reverse proxy
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// Serve the dashboard
app.UseDefaultFiles();
app.UseStaticFiles();

// Map YARP routes
app.MapReverseProxy();

app.Run();
