using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class signinModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Person personinfo { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(string user_type)
        {


                

            try
            {
                
                string connectionString = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";



                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    con.Open();
                    if(personinfo.Email == null) {
                        TempData["ErrorMessage"] = "The Email is required";
                        return Page(); 
                    }
                    if (personinfo.User_Password == null)
                    {
                        TempData["ErrorMessage"] = "The Password is required";
                        return Page();
                    }
                    string validation = "select count(*) from Userr where Userr.Email = @Email and Userr.User_Password = @User_Password";
                    using (SqlCommand cmd = new SqlCommand(validation, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", personinfo.Email);
                        cmd.Parameters.AddWithValue("@User_Password", personinfo.User_Password);
                        int counter = Convert.ToInt32(cmd.ExecuteScalar());
                        if (counter == 0)
                        {
                            TempData["ErrorMessage"] = "Wrong Email or Password";
                            return Page();
                        }
                    }

                    string q2 = "SELECT * FROM Userr " +
                                "WHERE Userr.Email = @Email and Userr.User_Password = @User_Password";

                    using (SqlCommand cmd = new SqlCommand(q2, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", personinfo.Email);
                        cmd.Parameters.AddWithValue("@User_Password", personinfo.User_Password);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            personinfo.Id = Convert.ToInt32(reader["ID"]);
                            personinfo.User_Type = reader["User_Type"].ToString();
                            personinfo.Phone_Number = reader["Phone_Number"].ToString();
                            personinfo.User_Password = reader["User_Password"].ToString();
                            personinfo.UserName = reader["UserName"].ToString();



                        }
                        HttpContext.Session.SetString("UserId", personinfo.Id.ToString());
                    }

                    //if (!ModelState.IsValid)
                    //{
                    //    foreach (var modelState in ModelState.Values)
                    //    {
                    //        foreach (var error in modelState.Errors)
                    //        {
                    //            TempData["ErrorMessage"] = error.ErrorMessage;
                    //            Console.WriteLine($"Model error: {error.ErrorMessage}");
                    //        }
                    //    }
                    //    return Page();
                    //}
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            if (personinfo.User_Type == "Cooker")
            {
                return RedirectToPage("/CookerProfile", new { ID2 = personinfo.Id });
            }
            else if (personinfo.User_Type == "Customer")
            {
                return RedirectToPage("/Profile", new { ID2 = personinfo.Id });
            }
            else
            {
                return RedirectToPage("/DeliveryProfile", new { ID2 = personinfo.Id });
            }
        }


    }
}
