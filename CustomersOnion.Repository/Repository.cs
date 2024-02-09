using CustomersOnion.Data;
using CustomersOnion.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersOnion.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Customer> entity;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            entity = _context.Set<Customer>();
        }

        public IEnumerable<Customer> GetAll() => entity.AsEnumerable();

        public Customer GetById(int Id) => entity.FirstOrDefault(x => x.Id == Id);

        public Customer Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public Customer Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();

            return customer;
        }

        public Customer Remove(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return customer;
        }
    }
}
