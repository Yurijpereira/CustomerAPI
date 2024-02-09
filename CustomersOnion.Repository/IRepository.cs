using CustomersOnion.Domain.Models;

namespace CustomersOnion.Repository
{
    public interface IRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int Id);
        Customer Create(Customer customer);
        Customer Update(Customer customer);
        Customer Remove(Customer customer);
    }
}
