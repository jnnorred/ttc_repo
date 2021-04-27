using System.Collections.Generic;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        // GET: api/menu
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<MenuItem> Get()
        {
            IGetAllMenu myObject = new ReadMenuData(); 
            return myObject.GetAllMenu(); 
         
        }

        // GET: api/menu/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetFood")]
        public MenuItem Get(int id)
        {
            IGetMenuItem myObject = new ReadMenuData(); 
            return myObject.GetItem(id); 
        }

        // POST: api/ttc
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/ttc/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/ttc/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}