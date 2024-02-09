using CustomersOnion.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersOnion.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
