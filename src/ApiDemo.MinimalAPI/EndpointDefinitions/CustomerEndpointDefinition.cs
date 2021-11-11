using ApiDemo.MinimalAPI.Models;
using ApiDemo.MinimalAPI.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace ApiDemo.MinimalAPI.EndpointDefinitions;

public class CustomerEndpointDefinition : IEndpointDefinition
{
    public void DefineServices(IServiceCollection services)
    {
        services.AddSingleton<ICustomerRepository, CustomerRepository>();
        services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Customer>());
    }

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/customers", GetAllCustomers)
            .Produces<IList<Customer>>()
            .AllowAnonymous();

        app.MapGet("/customers/{id}", GetCustomerById)
            .Produces<Customer>();

        app.MapPost("/customers", CreateNewCustomer)
            .Produces<Customer>();

        app.MapDelete("/customers/{id}", DeleteCustomer)
            .Produces<Customer>();
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

    internal IResult CreateNewCustomer(ICustomerRepository repo, IValidator<Customer> validator, Customer customer)
    {
        var validationResult = validator.Validate(customer);

        if (validationResult.IsValid is false)
        {
            var errors = new { errors = validationResult.Errors.Select(e => e.ErrorMessage) };
            return Results.BadRequest(errors);
        }

        repo.Create(customer);
        return Results.Created($"/customers/{customer.id}", customer);
    }

    internal IResult DeleteCustomer(ICustomerRepository repo, Guid id)
    {
        repo.Delete(id);
        return Results.Ok();
    }
}