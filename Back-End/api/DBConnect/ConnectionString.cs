namespace api.DBConnect
{
    public class ConnectionString
    {
        public string cs {get; set;}
        public ConnectionString(){
            string server = "vkh7buea61avxg07.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "f7zn6070xexawwx5";
            string port = "3306";
            string username = "wcbq1h91dir15qa7"; 
            string password = "ni5nh4syh911yipu"; 

            cs = $@"server = {server};user={username};database={database};port={port};password={password};"; 
        }
    }
}