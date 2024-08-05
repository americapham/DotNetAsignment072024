using System.Runtime.InteropServices;
using FirstCtrlWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstCtrlWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly List<Customer> _customers;

        public CustomersController()
        {
            _customers = new List<Customer>()
            {
                new() {CustomerId=1000, ContactName="Alisha C.", City="Mumbai"},
                new() {CustomerId=1001, ContactName="Manish Kaushik", City="Bengluru"},
                new() {CustomerId=1002, ContactName="Alisha Fasal", City="Bengluru"}
            };
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customers;
        }

        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _customers.Find(c => c.CustomerId == id);
        }

        [HttpGet("{city:alpha}/{startsWith:alpha}")]
        public IEnumerable<Customer> Get(string city, string startsWith)
        {
            return _customers.Where(c => c.City.Equals(city) && c.ContactName.StartsWith(startsWith));
        }

        [HttpPost]
        public IEnumerable<Customer> Post(Customer cus)
        {
            _customers.Add(cus);
            return _customers;
        }

        [HttpPut]
        public IEnumerable<Customer> Put(int id, Customer customer)
        {
            var existingCust = _customers.Find(c => c.CustomerId == id);
            existingCust.ContactName = customer.ContactName;
            existingCust.City = customer.City; 
            return _customers;
        }

        [HttpDelete]
        public IEnumerable<Customer> Delete(Customer customer)
        {
            var existingCust = _customers.Find(c => c.CustomerId == customer.CustomerId);
            if (existingCust != null)
            {
                _customers.Remove(existingCust);
            }
            return _customers;
        }


    }
}
