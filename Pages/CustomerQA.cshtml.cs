using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class customerQAModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Customer customerinfo { get; set; }

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
                //string connectionString = "Data Source =Tamer; Initial Catalog = Project 2.0; Integrated Security = True";
                //string connectionString = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";
                string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q = "INSERT INTO Customer" +
                         "(customer_id, city,street,Apartment_Number) VALUES" +
                        "(@customer_id, @city,@street,@Apartment_Number)";

                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        cmd.Parameters.AddWithValue("@customer_id", ID);
                        cmd.Parameters.AddWithValue("@city", customerinfo.city);
                        cmd.Parameters.AddWithValue("@street", customerinfo.street);
                        cmd.Parameters.AddWithValue("@Apartment_Number", customerinfo.Apartment_Number);


                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return RedirectToPage("/Profile", new { ID2 = ID });

        }

    }
}
