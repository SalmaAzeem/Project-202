using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class DeliveryQAModel : PageModel
    {
        [BindProperty (SupportsGet = true)]
        public Person personinfo2 { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {

            try
            {

                string connectionString = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q = "INSERT INTO Delivery" +
                        "(Vehicle_number, delivery_id) VALUES" +
                        "(@Vehicle_number,@delivery_id)";

                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        cmd.Parameters.AddWithValue("@delivery_id", personinfo2.Id);
                        cmd.Parameters.AddWithValue("@Vehicle_number", personinfo2.Vehicle_number);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
            return RedirectToPage("/DeliveryProfile", new { personinfo3 = personinfo2 });
            
        }

    }
}
