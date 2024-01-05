using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;

namespace Project_DB.Pages.Shared
{
    public class DoneModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int order_id { get; set; }

        [BindProperty(SupportsGet = true)]
        public int cooker_id { get; set; }
        public List<order> orderlist = new List<order>();

        public IActionResult OnGet()
        {
            try
            {
                string connectionString = "Data Source =Tamer; Initial Catalog = Project 2.0; Integrated Security = True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string selection = "SELECT o.order_id, c.meal_id, m.Meal_Name " +
                                        "FROM Orders AS o, Participate_In_Meals AS p, Cooks_Meal AS c, Meals AS m " +
                                        "WHERE o.order_id = p.order_id AND c.meal_id = p.meal_id AND c.meal_id = m.meal_id " +
                                        "AND o.order_status = 'Not Delivered' AND c.Cooker_id = @ID and ";

                    String q = "UPDATE Orders" +
                        " SET cooking_status='Done'" +
                        " WHERE order_id=@ID";

                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {

                        cmd.Parameters.AddWithValue("@ID", order_id);
                        cmd.ExecuteNonQuery();

                    }
                    using (SqlCommand cmd = new SqlCommand(selection, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", cooker_id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                order order = new order();
                                order.cooker_Id = cooker_id;
                                order.order_Id = reader.GetInt32(0);
                                order.meal_Id = reader.GetInt32(1);
                                order.meal_Name = reader.GetString(2);

                                orderlist.Add(order);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return RedirectToPage("/CookerProfile", new { ID2 = cooker_id });

        }
    }
}

