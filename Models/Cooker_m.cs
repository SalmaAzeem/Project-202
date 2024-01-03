using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Project_DB.Models
{
    [BindProperties(SupportsGet = true)]
    public class Cooker_m
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public byte[] Image_Cooker { get; set; }
        public int Phone_Number { get; set; }
        public string Email { get; set; }
        //[Required(ErrorMessage = "Please Enter a password with minimum 4 characters")]
        //[StringLength(100, MinimumLength = 4, ErrorMessage = "Invalid, Password should be more than 4 characters")]
        public string User_Password { get; set; }



    }
}
