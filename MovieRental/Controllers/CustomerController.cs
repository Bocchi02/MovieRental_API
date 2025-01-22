using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRental.Models;

namespace MovieRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MovieRentalDBContext DBcontext;

        public CustomerController(MovieRentalDBContext context)
        {
            DBcontext = context;
        }

        [HttpGet]
        public List<Customer> GetCustomers()
        {
            return DBcontext.Customer.ToList();
        }

        [HttpGet("id={id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = DBcontext.Customer.FirstOrDefault(c => c.CustomerID == id);

            if (customer == null)
                return NotFound();

            return customer;
        }

        [HttpGet("lastname={Lastname}")]
        public ActionResult<Customer> GetCustomerByLastname(string lastname)
        {
            var customer = DBcontext.Customer.FirstOrDefault(ln => ln.Lastname == lastname);

            if (customer == null)
                return NotFound();

            return customer;
        }

        [HttpGet("firstname={Firstname}")]
        public ActionResult<Customer> GetCustomerByFirstname(string firstname)
        {
            var customer = DBcontext.Customer.FirstOrDefault(fn => fn.Firstname == firstname);

            if (customer == null)
                return NotFound();

            return customer;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddStudent([FromBody] Customer customer)
        {
            DBcontext.Customer.Add(customer);
            await DBcontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerID }, customer);
        }

        [HttpPut("id={id}")]
        public async Task<IActionResult> UpdateCustomerDetails(int id,[FromBody] Customer customer)
        {
            if (id != customer.CustomerID)
                return BadRequest();

            DBcontext.Entry(customer).State = EntityState.Modified;

            try
            {
                await DBcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DBcontext.Customer.Any(c => c.CustomerID == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("id={id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = DBcontext.Customer.Find(id);
            if (customer == null)
                return NotFound();

            DBcontext.Customer.Remove(customer);
            await DBcontext.SaveChangesAsync();

            return NoContent();
        }

    }
}
