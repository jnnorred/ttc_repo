using api.DBConnect;
using api.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models
{
    public class SaveCustomer : IInsertCustomer
    {
        public void InsertCustomer(Customer value)
        {
            DBConnection db = new DBConnection(); 
            bool isOpen = db.OpenConnection(); 
            if (isOpen)
            {
                MySqlConnection conn = db.GetConn(); 
                string stm = @"INSERT INTO customer(FName, LName, Company, Phone, Email) VALUES(@FName, @LName, @Company, @Phone, @Email)"; 
                MySqlCommand cmd = new MySqlCommand(stm, conn); 
                
                cmd.Parameters.AddWithValue("@FName", value.FName);
                cmd.Parameters.AddWithValue("@LName", value.LName);
                cmd.Parameters.AddWithValue("@Company", value.Company);
                cmd.Parameters.AddWithValue("@Phone", value.Phone);
                cmd.Parameters.AddWithValue("@Email", value.Email);
                cmd.Prepare(); 
                cmd.ExecuteNonQuery(); 
                db.CloseConnection(); 
            }
        }

        public void InsertMessage(CustomerMessage value)
        {
            DBConnection db = new DBConnection(); 
            bool isOpen = db.OpenConnection(); 
            if (isOpen)
            {
                MySqlConnection conn = db.GetConn(); 
                string stm = @"INSERT INTO customer_message(Cust_ID, message) VALUES(@Cust_ID, @message)"; 
                MySqlCommand cmd = new MySqlCommand(stm, conn); 
                
                cmd.Parameters.AddWithValue("@Cust_ID", value.CustID);
                cmd.Parameters.AddWithValue("@message", value.Message);
                cmd.Prepare(); 
                cmd.ExecuteNonQuery(); 
                db.CloseConnection(); 
            }
        }

        public void UpdateCustomer(int id, Customer value)
        {
            throw new System.NotImplementedException();
        }
    }
}