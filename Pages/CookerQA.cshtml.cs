using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class CookerQAcshtmlModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Cooker cookerinfo { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {

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

                string connectionString = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q = "INSERT INTO Cooker" +
                        "(Cooker_id, city,street,Apartment_Number,Description_Cooker,Cooker_Image) VALUES" +
                        "(@Cooker_id, @city,@street,@Apartment_Number,@Description_Cooker,@Cooker_Image)";

                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        cmd.Parameters.AddWithValue("@Cooker_id", ID);
                        cmd.Parameters.AddWithValue("@city", cookerinfo.city);
                        cmd.Parameters.AddWithValue("@street", cookerinfo.street);
                        cmd.Parameters.AddWithValue("@Apartment_Number", cookerinfo.Apartment_Number);
                        cmd.Parameters.AddWithValue("@Description_Cooker", cookerinfo.Description);
                        cmd.Parameters.AddWithValue("@Cooker_Image", 00100);


                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return RedirectToPage("/CookerProfile", new { ID2 = ID });

        }

    }
}
