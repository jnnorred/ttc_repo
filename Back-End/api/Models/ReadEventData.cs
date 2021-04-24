using System.Collections.Generic;
using api.DBConnect;
using api.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models
{
    public class ReadEventData : IGetAllEvents, IGetEvent
    {
        public List<Event> GetAllEvents()
        {
            ConnectionString myConnection = new ConnectionString(); 
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open(); 


            string stm = "SELECT * FROM event LEFT JOIN customer ON event.Cust_ID = customer.Cust_ID";
            using var cmd = new MySqlCommand(stm,con); 

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<Customer> customersEvent = new List<Customer>(); 
            List<Event> allEvent = new List<Event>(); 

            while (rdr.Read())
            {
                allEvent.Add(new Event(){EventID = rdr.GetInt32(0),
                    EventDate = rdr.GetDateTime(1),
                    EventTime = rdr.GetString(2),
                    Cost = rdr.GetDouble(3),
                    Customer = new Customer(){
                    CustID = rdr.GetInt32(5),
                    AccountNo = rdr.GetString(6), 
                    FName = rdr.GetString(7),
                    LName = rdr.GetString(8),
                    Company = rdr.GetString(9),
                    Phone = rdr.GetString(10)}});

            }
            return allEvent; 
        }

        public List<Event> GetAllUpComingEvents()
        {
            ConnectionString myConnection = new ConnectionString(); 
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open(); 


            string stm = "SELECT * FROM event WHERE DATEDIFF(Event_Date, NOW()) >= 1";
            using var cmd = new MySqlCommand(stm,con); 

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<Customer> customersEvent = new List<Customer>(); 
            List<Event> allEvent = new List<Event>(); 

            while (rdr.Read())
            {
                allEvent.Add(new Event(){EventID = rdr.GetInt32(0),
                    EventDate = rdr.GetDateTime(1),
                    EventTime = rdr.GetString(2),
                    Cost = rdr.GetDouble(3)});

            }
            return allEvent; 
        }
        public Event GetEvent(int id)
        {
            ConnectionString myConnection = new ConnectionString(); 
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open(); 


            string stm = "SELECT * FROM event LEFT JOIN customer ON event.Cust_ID = customer.Cust_ID WHERE event.Cust_ID = @id";
            using var cmd = new MySqlCommand(stm,con); 
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare(); 
            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read(); 
            return new Event(){EventID = rdr.GetInt32(0),
                    EventDate = rdr.GetDateTime(1),
                    EventTime = rdr.GetString(2),
                    Cost = rdr.GetDouble(3),
                Customer = new Customer(){
                    CustID = rdr.GetInt32(5),
                    AccountNo = rdr.GetString(6), 
                    FName = rdr.GetString(7),
                    LName = rdr.GetString(8),
                    Company = rdr.GetString(9),
                    Phone = rdr.GetString(10)}};
        }

        public Event NextEvent()
        {
            ConnectionString myConnection = new ConnectionString(); 
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open(); 


            string stm = "SELECT Event_ID, Event_Date, Event_Time, Cost, Event.Cust_ID, Customer.FName, Customer.LName, DATEDIFF(Event_Date,NOW()) AS TimeDifference FROM event LEFT JOIN customer ON event.Cust_ID = customer.Cust_ID WHERE event.Cust_ID = customer.Cust_ID AND Event_Date > NOW() ORDER BY Event_Date LIMIT 1";
            using var cmd = new MySqlCommand(stm,con); 
            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read(); 
            return new Event(){EventID = rdr.GetInt32(0),
                    EventDate = rdr.GetDateTime(1),
                    EventTime = rdr.GetString(2),
                    Cost = rdr.GetDouble(3),
                Customer = new Customer(){
                    CustID = rdr.GetInt32(4),
                    FName = rdr.GetString(5),
                    LName = rdr.GetString(6),
                    TimeDifference = rdr.GetInt32(7)}};
        }
    }
}