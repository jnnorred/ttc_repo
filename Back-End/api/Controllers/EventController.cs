using System.Collections.Generic;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        // GET: api/event
        [HttpGet]
        public List<Event> Get()
        {
            IGetAllEvents myObject = new ReadEventData(); 
            return myObject.GetAllEvents(); 
        }

        // GET: api/event/5
        [HttpGet("{id}", Name = "Get")]
        public Event Get(int id)
        {
            IGetEvent myObject = new ReadEventData();
            return myObject.GetEvent(id); 
        }
                
    }
}