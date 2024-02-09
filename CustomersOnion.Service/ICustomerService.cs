using CustomersOnion.Domain.Models;
using CustomersOnion.Domain.ViewModel;

namespace CustomersOnion.Service
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllProduct();
        Customer GetProductById(int Id);
        Customer Create (CreateCustomerViewModel model);
        Customer Update (CreateCustomerViewModel model, int id);
        Customer Remove (int id);
    }
}
