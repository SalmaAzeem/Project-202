using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;
using System.Data.SqlClient;
using System.Runtime;

namespace Project_DB.Pages
{
    public class PasswordModel : PageModel
    {
        [BindProperty (SupportsGet =true)]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "the password should be minimum 4 charaters")]
        public string pass { get; set; }
        [BindProperty(SupportsGet = true)]
        public string passconfigeration { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ID3 { get; set; }

        [BindProperty(SupportsGet = true)]
        public string type { get; set; }
        public void OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if(userId != null) { ID3 = userId.Value; }
            
            try
            {
                string connectionString = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q1 = "SELECT * FROM Userr WHERE ID=@ID";
                    using (SqlCommand cmd = new SqlCommand(q1, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID3);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                pass = reader.GetString(5);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public IActionResult OnPost()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null) { ID3 = userId.Value; }
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
            if (pass != passconfigeration)
            {
                TempData["ErrorMessage"] = "The Passwords does not match.";
                //Console.WriteLine($"Model error: {TempData["ErrorMessage"]}");
                return Page();
            }
            else
            {

                //Console.WriteLine($"Type: {type}");
                try
                {
                    string connectionString = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        String q = "UPDATE Userr" +
                            " SET User_Password = @pass" +
                            " WHERE ID=@ID";

                        using (SqlCommand cmd = new SqlCommand(q, con))
                        {
                            cmd.Parameters.AddWithValue("@pass", pass);
                            cmd.Parameters.AddWithValue("@ID", ID3);


                            cmd.ExecuteNonQuery();

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                if(type == "\'Cooker\'")
                {
                    return RedirectToPage("/CookerProfile", new { ID2 = ID3 } );
                }
                else if(type == "\'Driver\'")
                {
                    return RedirectToPage("/DeliveryProfile", new { ID2 = ID3 });
                }
                else
                {
                    return RedirectToPage("/Profile", new { ID2 = ID3 });
                }
            }
            
        }
    }
}
