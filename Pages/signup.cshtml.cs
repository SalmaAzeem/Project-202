using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Runtime;

namespace Project_DB.Pages
{
    public class signupModel : PageModel
    {
        public Person personinfo = new Person();
        public void OnGet()
        {
        }

        public void OnPost() { 
            personinfo.UserName = Request.Form["UserName"];
            string passString = Request.Form["User_Password"];
            personinfo.Email = Request.Form["Email"];
            personinfo.User_Password = Request.Form["User_Password"];
            personinfo.User_Type = Request.Form["User_Type"];
            personinfo.Phone_Number = Request.Form["Phone_Number"];
            personinfo.Birthdate = Request.Form["Birthdate"];



        try
        {
                string connectionString = "Data Source = LAPTOP - 8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q = "INSERT INTO Userr" +
                        "(UserName,Email,Phone_Number,User_Password,Birthdate,User_Type) VALUES" +
                        "(@UserName,@Email,@Phone_Number,@User_Password,@Birthdate,@User_Type)";

                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        cmd.Parameters.AddWithValue("@UserName", personinfo.UserName);
                        cmd.Parameters.AddWithValue("@User_Password", personinfo.User_Password);
                        cmd.Parameters.AddWithValue("@Email", personinfo.Email);
                        cmd.Parameters.AddWithValue("@phone", personinfo.Phone_Number);
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
                Console.WriteLine(personinfo.User_Type);
            Response.Redirect("/CookerProfile", new { personinfo = presoninfo2 });
            }
            else if(personinfo.User_Type == "Customer")
            {
                Response.Redirect("/Profile", new { personinfo = presoninfo2 });
            }
            else
            {
                Response.Redirect("/DeliveryProfile",new { personinfo = presoninfo2 });
            }


            

        }

    }
}
