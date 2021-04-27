using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface IGetCustomer
    {
        Customer GetCustomer(int id);

        Customer GetCustomerInvoices(int id);
        // List<Customer> GetCustomerInvoices(int id);
    }
}