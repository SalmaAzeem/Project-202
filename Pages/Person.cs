﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;


namespace Project_DB.Models
{
    [BindProperties(SupportsGet = true)]
    public class Person
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please Enter your name with minimum 3 characters")]
        [MinLength(3, ErrorMessage = "Invalid, Name should be more than 3 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter your email with an '@' in it and a '.com' in the end")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid, Email should contain an @")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter a number of 11 characters")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Please Enter a number of 11 characters")]
        public string Phone_Number { get; set; }

        [Required(ErrorMessage = "Please Enter a password with minimum 4 characters")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Invalid, Password should be more than 4 characters")]
        public string User_Password { get; set; }


        //[Required(ErrorMessage = "Please choose one")]
        public string? User_Type { get; set; }


    }
}

