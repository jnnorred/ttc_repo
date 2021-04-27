using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface IGetAllEvents
    {
        List<Event> GetAllEvents(); 
        List<Event> GetAllUpComingEvents(); 
    }
}