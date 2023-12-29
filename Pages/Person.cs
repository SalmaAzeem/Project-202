using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    [BindProperties(SupportsGet = true)]
    public class Person
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        public int Phone_Number { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        public string User_Password { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        public string Birthdate { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        public string User_Type { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        public int Vehicle_number { get; set;}
        public string Description { get; set; }
    }
}
