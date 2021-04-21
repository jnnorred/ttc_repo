using api.Models;

namespace api.Interfaces
{
    public interface IGetCustomer
    {
        Customer GetCustomer(int id);
    }
}