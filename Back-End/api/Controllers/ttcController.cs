using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ttcController : ControllerBase
    {
        // GET: api/ttc
        [HttpGet]
        public List<Customer> Get()
        {
            IGetAllCustomers myObject = new ReadCustomerData();
            return myObject.GetAllCustomers(); 
            // IGetAllEvents myObject = new ReadEventData(); 
            // return myObject.GetAllEvents(); 
        }

        // GET: api/ttc/5
        [HttpGet("{id}", Name = "Get")]
        public Customer Get(int id)
        {
            IGetCustomer myObject = new ReadCustomerData(); 
            return myObject.GetCustomer(id);
        }

        // POST: api/ttc
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ttc/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ttc/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
