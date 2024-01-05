using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Runtime;

namespace Project_DB.Pages
{
    [BindProperties(SupportsGet = true)]
    public class DeliveryProfileModel : PageModel
    {
        public int ID2 { get; set; }
        public Driver deliveryinfo { get; set; }
        public List<Orders> orders { get; set; } = new List<Orders>();
        public int order_id { get; set; }
        public void OnGet(int ID2)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null)
            {
                ID2 = userId.Value;

            }
            try
            {
                string connectionString = "Data Source =Tamer; Initial Catalog = Project 2.0; Integrated Security = True";
                //string connectionString = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";

                //deliveryinfo.Id = ID2;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q2 = "SELECT * FROM Userr " +
                                "INNER JOIN Delivery ON Userr.ID = Delivery.delivery_id " +
                                "WHERE Userr.ID = @ID";
                    using (SqlCommand cmd = new SqlCommand(q2, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID2);
                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            //deliveryinfo.Id = Convert.ToInt32(reader["ID"]);
                            deliveryinfo.UserName = reader["UserName"].ToString();
                            deliveryinfo.Email = reader["Email"].ToString();
                            deliveryinfo.Phone_Number = reader["Phone_Number"].ToString();
                            deliveryinfo.Vehicle_number = reader["Vehicle_number"].ToString();
                            deliveryinfo.User_Password = reader["User_Password"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            try
            {
                string connection = "Data Source =Tamer; Initial Catalog = Project 2.0; Integrated Security = True";
                //string connection = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    string query_all_orders = "select * from Orders where delivery_id = @Id and cooking_status = 'Pending'";
                    using (SqlCommand cmd = new SqlCommand(query_all_orders, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", ID2);
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
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try
            {
                string connection = "Data Source =Tamer; Initial Catalog = Project 2.0; Integrated Security = True";
                //string connection = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";

                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    string query_get_orders = "select Destination, city from Orders as o inner join Delivery as d on o.delivery_id = d.delivery_id where d.delivery_id = @Id and Destination is not null ";
                    using (SqlCommand cmd = new SqlCommand(query_get_orders, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", ID2);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
            
                                deliveryinfo.city = reader["city"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
       
        public void OnPostReject()
        {
            Console.WriteLine("Method reject worked");
        }
    }
}
