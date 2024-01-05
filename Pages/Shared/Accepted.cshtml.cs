using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages.Shared
{
    [BindProperties(SupportsGet=true)]
    public class AcceptedModel : PageModel
    {
        public int order_id { get; set; }
        public int delivery_id { get; set; }
        public List<Orders> orders { get; set; } = new List<Orders>();

        public void OnGet()
        {
            string connection = "Data Source =Tamer; Initial Catalog = Project 2.0; Integrated Security = True";

            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    string query = "update Orders set order_status = 'Delivered', cooking_status = 'Done' where order_id = @orderID";
                    string query_all_orders = "select * from Orders where delivery_id = @Id and cooking_status = 'Pending'";
                    using (SqlCommand cmd = new SqlCommand(query_all_orders, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", delivery_id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Orders new_order = new Orders();
                                new_order.order_id = Convert.ToInt32(reader["order_id"]);
                                new_order.payment_type = reader["payment_type"].ToString();
                                new_order.destination = reader["Destination"].ToString();
                                new_order.order_status = reader["order_status"].ToString();
                                new_order.customer_id = Convert.ToInt32(reader["customer_id"]);
                                orders.Add(new_order);
                            }
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@orderID", order_id);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("executed");
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }

            Console.WriteLine("done");
        }
        //public IActionResult OnPostAccep()
        //{
            
        //}
    }
}
