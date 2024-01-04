using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using System.Runtime;
using System.ComponentModel.DataAnnotations;
using Project_DB.Models;
using System.Windows.Input;


namespace Project_DB.Pages
{
    public class signupModel : PageModel
    {
        [BindProperty (SupportsGet =true)]
        public Person personinfo { get; set; }

        Random rnd = new Random();

        //[BindProperty(SupportsGet =true)]
        //public DB db { get; set; }

        [Required(ErrorMessage = "Please choose one")]
        public string type { get; set; }

        //public signupModel(DB db2)
        //{
        //    this.db = db2;
        //}

        public void OnGet()
        {
        }

        public IActionResult OnPost(string user_type) {
            

            personinfo.User_Type = user_type;
            type = user_type;
            
            personinfo.Id = rnd.Next();
            try
             {
                if (!ModelState.IsValid)
                {
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var error in modelState.Errors)
                        {
                            TempData["ErrorMessage"] = error.ErrorMessage;
                            Console.WriteLine($"Model error: {error.ErrorMessage}");
                        }
                    }
                    return Page();
                }
                string connectionString = "Data Source=Salma_Sherif;Initial Catalog=\"Project 2.0\";Integrated Security=True";

                

                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    con.Open();
                    string validation = "select count(*) from Userr where Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(validation, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", personinfo.Email);
                        int counter = Convert.ToInt32(cmd.ExecuteScalar());
                        if (counter > 0)
                        {
                            TempData["ErrorMessage"] = "This Email already in use, Please choose another one";
                            return Page();
                        }
                    }
                    string validation2 = "select count(*) from Userr where User_Password = @User_Password";
                    using (SqlCommand cmd = new SqlCommand(validation2, con))
                    {
                        cmd.Parameters.AddWithValue("@User_Password", personinfo.User_Password);
                        int counter = Convert.ToInt32(cmd.ExecuteScalar());
                        if (counter > 0)
                        {
                            TempData["ErrorMessage"] = "The current password may be in use or is considered weak for security reasons.";
                            return Page();
                        }
                    }

                    string q = "INSERT INTO Userr" +
                        "(ID, UserName,Email,Phone_Number,User_Password,User_Type) VALUES" +
                        "(@ID, @UserName,@Email,@Phone_Number,@User_Password,@User_Type)";

                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {

                      
                        cmd.Parameters.AddWithValue("@ID", personinfo.Id);
                        cmd.Parameters.AddWithValue("@UserName", personinfo.UserName);
                        cmd.Parameters.AddWithValue("@User_Password", personinfo.User_Password);
                        cmd.Parameters.AddWithValue("@Email", personinfo.Email);
                        cmd.Parameters.AddWithValue("@Phone_Number", personinfo.Phone_Number);
                        cmd.Parameters.AddWithValue("@User_Type", personinfo.User_Type);
                        cmd.ExecuteNonQuery();

                    }
                   
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
            if (personinfo.User_Type == "Cooker")
            {
                return RedirectToPage("/CookerQA", new { ID = personinfo.Id });
            }
            else if (personinfo.User_Type == "Customer")
            {
                return RedirectToPage("/CustomerQA", new { ID = personinfo.Id });
            }
            else
            {
                return RedirectToPage("/DeliveryQA", new { ID = personinfo.Id });
            }
        }

    }
}
