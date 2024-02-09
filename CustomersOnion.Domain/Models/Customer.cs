namespace CustomersOnion.Domain.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Cpf { get; set; }
    }
}
