using ApiDemo.MinimalAPI.Models;
using ApiDemo.MinimalAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

// Configure the services
builder.Services.AddEndpointDefinition(typeof(Customer));

var app = builder.Build();

// Configure endpoints and middleware
app.UseEndpointDefinitions();

// Run the application
app.Run();