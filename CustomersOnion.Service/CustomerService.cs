using CustomersOnion.Domain.Models;
using CustomersOnion.Domain.ViewModel;
using CustomersOnion.Repository;

namespace CustomersOnion.Service
{
    public class CustomerService : ICustomerService
    {
        private IRepository _repository;

        public CustomerService(IRepository repository) => _repository = repository;

        public IEnumerable<Customer> GetAllProduct() => _repository.GetAll();

        public Customer GetProductById(int Id) => _repository.GetById(Id);

        public Customer Create(CreateCustomerViewModel model)
        {
            var customer = new Customer()
            {
                Name = model.Name,
                Email = model.Email,
                Number = model.Number,
                Cpf = model.Cpf
            };

            return _repository.Create(customer);
        }

        public Customer Update(CreateCustomerViewModel model, int id)
        {
            var customer = GetProductById(id);

            customer.Name = model.Name;
            customer.Email = model.Email;
            customer.Number = model.Number;
            customer.Cpf = model.Cpf;

            return _repository.Update(customer);
        }

        public Customer Remove(int id)
        {
            var customer = GetProductById(id);

            return _repository.Remove(customer);
        }
    }
}
