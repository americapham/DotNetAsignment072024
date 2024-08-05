using FirstCtrlWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstCtrlWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoschCustomerController : ControllerBase
    {
        private readonly List<Customer> _customers;

        public BoschCustomerController()
        {
            _customers = new List<Customer>()
            {
                new() {CustomerId=1000, ContactName="Alisha C.", City="Mumbai"},
                new() {CustomerId=1001, ContactName="Manish Kaushik", City="Bengluru"},
                new() {CustomerId=1002, ContactName="Alisha Fasal", City="Bengluru"}
            };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Customer>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCustomers()
        {
            if (_customers.Count > 0)
            {
                return Ok(_customers);
            } else
            {
            return NotFound(new {ErrorMessage="We didn't find any customers! Please try after some time!"});

            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Customer>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Customer>> GetCustomerDetails(int id)
        {
            var cust = _customers.Find(c => c.CustomerId == id);
            if (cust != null)
            {
                return Ok(_customers);
            }
            else
            {
                return NotFound(new { ErrorMessage = $"We didn't find any customer by Id {id}!" });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Customer> Post(Customer cust)
        {
            if (ModelState.IsValid)
            {
                _customers.Add(cust);
                //return CreatedAtAction("GetCustomerDetails", new { id = cust.CustomerId }, cust);
                return CreatedAtAction(nameof(GetCustomerDetails), new {id = cust.CustomerId}, cust);
            }
            return BadRequest();
        }
    }
}
