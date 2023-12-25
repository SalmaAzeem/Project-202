using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class Person
    {
        public string name { get; set; } 
        public string email { get; set; }
        public int phone { get; set; }

        public string password { get; set; }

        public string bdate { get; set; }

        public string type;
    }
}
