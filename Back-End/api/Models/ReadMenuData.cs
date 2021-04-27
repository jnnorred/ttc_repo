using System.Collections.Generic;
using api.DBConnect;
using api.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models
{
    public class ReadMenuData : IGetAllMenu, IGetMenuItem
    {
        public List<MenuItem> GetAllMenu()
        {
            ConnectionString myConnection = new ConnectionString(); 
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open(); 


            string stm = "SELECT * FROM fooditems";
            using var cmd = new MySqlCommand(stm,con); 

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<MenuItem> allMenuItems = new List<MenuItem>(); 
           

            while (rdr.Read())
            {
                allMenuItems.Add(new MenuItem(){foodId = rdr.GetInt32(0), foodName = rdr.GetString(1), description = rdr.GetString(2), price = rdr.GetDouble(3), listedItem = rdr.GetInt32(4)}); 

            }
            return allMenuItems; 
        }

        public MenuItem GetItem(int id)
        {
            ConnectionString myConnection = new ConnectionString(); 
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open(); 


            string stm = "SELECT * FROM fooditems WHERE foodId = @id";
            using var cmd = new MySqlCommand(stm,con); 
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare(); 
            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read(); 
            return new MenuItem(){foodId = rdr.GetInt32(0), foodName = rdr.GetString(1), description = rdr.GetString(2), price = rdr.GetDouble(3),listedItem = rdr.GetInt32(4)}; 
        }
    }
}