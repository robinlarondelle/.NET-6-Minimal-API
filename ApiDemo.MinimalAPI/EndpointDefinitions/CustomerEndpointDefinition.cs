using ApiDemo.MinimalAPI.Models;
using ApiDemo.MinimalAPI.Repositories;

namespace ApiDemo.MinimalAPI.Routes;

public class CustomerEndpointDefinition : IEndpointDefinition
{
    public void DefineServices(IServiceCollection services)
    {
        services.AddSingleton<ICustomerRepository, CustomerRepository>();
    }

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/customers", GetAllCustomers);
        app.MapGet("/customers/{id}", GetCustomerById);
        app.MapPost("/customers", CreateNewCustomer);
    }

    internal List<Customer> GetAllCustomers(ICustomerRepository repo)
    {
        return repo.GetAll();
    }

    internal IResult GetCustomerById(ICustomerRepository repo, Guid id)
    {
        var customer = repo.GetById(id);
        return customer is not null ? Results.Ok(customer) : Results.NotFound();
    }

    internal IResult CreateNewCustomer(ICustomerRepository repo, Customer customer)
    {
        repo.Create(customer);
        return Results.Created($"/customers/{customer.id}", customer);
    }
}