using System.ComponentModel.DataAnnotations;

namespace CustomersOnion.Domain.ViewModel
{
    public class CreateCustomerViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Cpf { get; set; }
    }
}
