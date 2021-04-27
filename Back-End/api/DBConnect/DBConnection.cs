using System;
using MySql.Data.MySqlClient;

namespace api.DBConnect
{
    public class DBConnection
    {
        private MySqlConnection connection; 
        private string server; 
        private string database; 
        private string username; 
        private string password; 
        private string port; 

        public DBConnection(){
            Initialize();
        }
        private void Initialize (){
            server = "vkh7buea61avxg07.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            database = "f7zn6070xexawwx5";
            port = "3306";
            username = "wcbq1h91dir15qa7"; 
            password = "ni5nh4syh911yipu"; 

            string cs = $@"server = {server};user={username};database={database};port={port};password={password};";
            connection = new MySqlConnection(cs); 
        }
        public bool OpenConnection(){
            try{
                connection.Open(); 
                return true; 
            }
            catch(MySqlException ex){
                if(ex.Number == 0){
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Cannot Connect"); 
                } else{ 
                    if(ex.Number == 1045){
                        Console.WriteLine("Invalid username/password"); 
                    }
                }
            }
            return false;
        }
        public bool CloseConnection(){
            try{
                connection.Close(); 
                return true; 
            }
            catch(MySqlException ex){
                Console.WriteLine(ex.Message);
            }
            return false; 
        }
        public MySqlConnection GetConn(){
            return connection; 
        }
    }
}