using ApiDemo.MinimalAPI.Models;

namespace ApiDemo.MinimalAPI.Repositories
{
    internal interface ICustomerRepository
    {
        void Create(Customer customer);
        void Delete(Guid id);
        List<Customer> GetAll();
        Customer GetById(Guid id);
        void Update(Customer customer);
    }
}