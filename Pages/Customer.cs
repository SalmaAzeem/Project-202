using System.ComponentModel.DataAnnotations;

namespace Project_DB.Pages
{
    public class Customer
    {
        public int Id { get; set; }
       
        public string? UserName { get; set; }
       
        public string? Phone_Number { get; set; }
        
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please Enter a City")]
        public string city { get; set; }
        [Required(ErrorMessage = "Please Enter a street name ")]

        public string street { get; set; }
        [Required(ErrorMessage = "Please Enter an Apatment number")]

        public string Apartment_Number { get; set; }

        public string? User_Password { get; set; }
    }
}
