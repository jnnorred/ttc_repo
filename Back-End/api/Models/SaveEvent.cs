using api.DBConnect;
using api.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models
{
    public class SaveEvent : IInsertEvent
    {
        public void InsertEvent(Event value)
        {
            DBConnection db = new DBConnection(); 
            bool isOpen = db.OpenConnection(); 
            if (isOpen)
            {
                MySqlConnection conn = db.GetConn(); 
                string stm = @"INSERT INTO event(Name, Event_Date, Event_Time, Cost, Cust_ID) VALUES(@Name, @Event_Date, @Event_Time, @Cost, @Cust_ID)"; 
                MySqlCommand cmd = new MySqlCommand(stm, conn); 
                
                cmd.Parameters.AddWithValue("@Name", value.EventName);
                cmd.Parameters.AddWithValue("@Event_Date", value.EventDate);
                cmd.Parameters.AddWithValue("@Event_Time", value.EventTime);
                cmd.Parameters.AddWithValue("@Cost", value.Cost);
                cmd.Parameters.AddWithValue("@Cust_ID", value.Customer.CustID);
                cmd.Prepare(); 
                cmd.ExecuteNonQuery(); 
                db.CloseConnection(); 
            }
        }
    }
}