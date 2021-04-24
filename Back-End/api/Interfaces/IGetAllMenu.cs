using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface IGetAllMenu
    {
         List<MenuItem> GetAllMenu();
    }
}