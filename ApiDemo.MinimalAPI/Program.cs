using ApiDemo.MinimalAPI.Models;
using ApiDemo.MinimalAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointDefinition(typeof(Customer));

var app = builder.Build();

app.UseEndpointDefinitions();

app.Run();