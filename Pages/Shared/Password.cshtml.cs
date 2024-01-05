using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.ComponentModel.Design.Serialization;
using System.Data.SqlClient;
using System.Runtime;

namespace Project_DB.Pages
{
    public class PasswordModel : PageModel
    {
        [BindProperty (SupportsGet =true)]
        public string pass { get; set; }
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
            Console.WriteLine($"Type: {type}");
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
            if(type == "\'Cooker\'\'")
            {
                return RedirectToPage("/CookerProfile", new { ID2 = ID3 } );
            }
            else if(type == "\'Driver\'\'")
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
