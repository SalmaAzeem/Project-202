using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    
    public class DeleteModel : PageModel
    {
        [BindProperty (SupportsGet = true)]
        public int ID { get; set; }

        [BindProperty(SupportsGet = true)]
        public int order_id { get; set; }
        public IActionResult OnGet()
        {
            //var userId = HttpContext.Session.GetString("UserId");
            //ID2 = userId.Value;
            try
            {
                string connectionString = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";

                //string selection = "SELECT o.order_id, c.meal_id, m.Meal_Name " +
                //                    "FROM Orders AS o, Participate_In_Meals AS p, Cooks_Meal AS c, Meals AS m " +
                //                    "WHERE o.order_id = p.order_id AND c.meal_id = p.meal_id AND c.meal_id = m.meal_id " +
                //                    "AND o.order_status = 'Not Delivered' AND c.Cooker_id = @ID";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q2 = "DELETE FROM Orders WHERE order_id=@ID";
                    string q3 = "DELETE FROM Invoices WHERE order_id=@ID";
                    string q4 = "DELETE FROM Participate_In_Meals WHERE order_id=@ID";
                    using (SqlCommand cmd = new SqlCommand(q4, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", order_id);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(q3, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", order_id);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(q2, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", order_id);
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
