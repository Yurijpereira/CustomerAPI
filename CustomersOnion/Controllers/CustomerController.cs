using CustomersOnion.Domain.ViewModel;
using CustomersOnion.Service;
using Microsoft.AspNetCore.Mvc;

namespace CustomersOnion.Controllers
{
    [ApiController]
    [Route("v1")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("customers")]
        public async Task<IActionResult> GetAsync()
        {
            var customers = _customerService
                .GetAllProduct();
            return Ok(customers);
        }

        [HttpGet]
        [Route("customers/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id)
        {
            var customer = _customerService
                .GetProductById(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
        }

        [HttpPost]
        [Route("customers")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CreateCustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var customer = _customerService
                    .Create(model);
                return Created("v1/customers/{customer.Id}", customer);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);

                return StatusCode(500, "Ocorreu um erro interno no servidor.");
            }
        }

        [HttpPut("customers/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromBody] CreateCustomerViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_customerService.GetProductById(id) == null)
            {
                return NotFound();
            }

            try
            {
                var customer = _customerService
                    .Update(model, id);

                return Ok(customer);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);

                return StatusCode(500, "Ocorreu um erro interno no servidor.");
            }
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id)
        {
            try
            {
                var customer = _customerService
                   .Remove(id);
                return Ok(customer);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);

                return StatusCode(500, "Ocorreu um erro interno no servidor.");
            }
        }
    }
}
