using System.Collections.Generic;

namespace api.Models
{
    public class Customer
    {
        public int CustID { get; set; }
        public string AccountNo { get; set; }
        public string FName {get; set;}
        public string LName {get; set;}
        public string Company {get; set;}
        public string Phone {get; set;}

        public string Email {get; set;}
        public int TimeDifference {get; set;}
        public Event Event {get; set;}
        public CustomerMessage Message{get; set;}

        public Invoice InvoiceSummary {get; set;}

        public List<Invoice> InvoiceList {get; set;}

    }
}