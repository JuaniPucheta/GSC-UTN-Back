using GrpcService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpcReflection();

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();
app.MapGrpcReflectionService();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
