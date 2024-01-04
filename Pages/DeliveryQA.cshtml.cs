using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class DeliveryQAModel : PageModel
    {
        [BindProperty (SupportsGet = true)]
        public Driver deliveryinfo { get; set; }

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
                string connectionString = "Data Source =Tamer; Initial Catalog = Project 2.0; Integrated Security = True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q = "INSERT INTO Delivery" +
                        "(Vehicle_number, delivery_id) VALUES" +
                        "(@Vehicle_number,@delivery_id)";

                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        cmd.Parameters.AddWithValue("@Vehicle_number", deliveryinfo.Vehicle_number);
                        cmd.Parameters.AddWithValue("@delivery_id", ID);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
            return RedirectToPage("/DeliveryProfile", new {ID2 = ID});
            
        }

    }
}
