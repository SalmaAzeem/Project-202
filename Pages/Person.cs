using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    [BindProperties(SupportsGet = true)]
    public class Person
    {
        public int Id { get; set; }
        public string UserName { get; set; } 
        public string Email { get; set; }
        public int Phone_Number { get; set; }
        public string User_Password { get; set; }
        public string Birthdate { get; set; }
        public string User_Type { get; set; }
        public int Vehicle_number { get; set;}
    }
}
