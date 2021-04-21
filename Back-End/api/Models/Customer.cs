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
        public Event Event {get; set;}
    }
}