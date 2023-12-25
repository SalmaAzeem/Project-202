using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using System.Runtime;

namespace Project_DB.Pages
{
    public class signupModel : PageModel
    {
        [BindProperty (SupportsGet =true)]
        public Person personinfo { get; set; }
        Random rnd = new Random();

        public void OnGet()
        {
        }

        public IActionResult OnPost() { 
            /*personinfo.UserName = Request.Form["UserName"];
            string passString = Request.Form["User_Password"];
            personinfo.Email = Request.Form["Email"];
            personinfo.User_Password = Request.Form["User_Password"];
            personinfo.User_Type = Request.Form["User_Type"];*/
            //string phoneString = Request.Form["Phone_Number"];


            /*if ()
            {
                personinfo.Phone_Number = idValue;
            }*/

            //personinfo.Birthdate = Request.Form["Birthdate"];



        try
        {
                string connectionString = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q = "INSERT INTO Userr" +
                        "(ID, UserName,Email,Phone_Number,User_Password,Birthdate,User_Type) VALUES" +
                        "(@ID, @UserName,@Email,@Phone_Number,@User_Password,@Birthdate,@User_Type)";

                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", rnd.Next());
                        cmd.Parameters.AddWithValue("@UserName", personinfo.UserName);
                        cmd.Parameters.AddWithValue("@User_Password", personinfo.User_Password);
                        cmd.Parameters.AddWithValue("@Email", personinfo.Email);
                        cmd.Parameters.AddWithValue("@Phone_Number", personinfo.Phone_Number);
                        cmd.Parameters.AddWithValue("@Birthdate", personinfo.Birthdate);
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
                return RedirectToPage("/CookerProfile", new { personinfo2 = personinfo });
            }
            else if (personinfo.User_Type == "Customer")
            {
                return RedirectToPage("/Profile", new { personinfo2 = personinfo });

            }
            else
            {
            return RedirectToPage("/DeliveryProfile", new { personinfo2 = personinfo });
            }
        }

    }
}
