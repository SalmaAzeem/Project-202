using System.ComponentModel.DataAnnotations;

namespace Project_DB.Pages
{
    public class Driver
    {
        public int Id { get; set; }

        public string? UserName { get; set; }
        public string? Description { get; set; }
        public byte[]? Image_Cooker { get; set; }

        public string? Phone_Number { get; set; }

        public string? Email { get; set; }

        public string? User_Password { get; set; }

       
        [Required(ErrorMessage = "Please enter your vechile number")]
        [StringLength(7,MinimumLength =3, ErrorMessage = "Should be a 4 or more charater")]
        public string Vehicle_number { get; set; }
        public string city { get; set; }
        public string destination { get; set; }

    }
}
