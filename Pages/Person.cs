using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class Person
    {
        public string UserName { get; set; } 
        public string Email { get; set; }
        public int Phone_Number { get; set; }
        public string User_Password { get; set; }
        public string Birthdate { get; set; }
        public string User_Type;
    }
}
