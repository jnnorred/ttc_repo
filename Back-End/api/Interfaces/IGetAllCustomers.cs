using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface IGetAllCustomers
    {
         List<Customer> GetAllCustomers();

         List<Customer> GetCustomerInquiries(); 

         List<Customer> GetCustomerDueAmount(); 
    }
}