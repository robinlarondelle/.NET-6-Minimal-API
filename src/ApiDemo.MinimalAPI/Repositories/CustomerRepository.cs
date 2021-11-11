using ApiDemo.MinimalAPI.Models;

namespace ApiDemo.MinimalAPI.Repositories;

class CustomerRepository : ICustomerRepository
{
    private readonly Dictionary<Guid, Customer> _customer = new();

    public void Create(Customer customer)
    {
        if (customer is null)
        {
            return;
        }

        _customer[customer.id] = customer;
    }

    public Customer GetById(Guid id)
    {
        return _customer[id];
    }

    public List<Customer> GetAll()
    {
        return _customer.Values.ToList();
    }

    public void Update(Customer customer)
    {
        var existingCustomer = GetById(customer.id);
        if (existingCustomer is null)
        {
            return;
        }

        _customer[customer.id] = customer;
    }

    public void Delete(Guid id)
    {
        _customer.Remove(id);
    }
}