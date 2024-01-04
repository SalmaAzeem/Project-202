using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.Data.SqlClient;
using System.Runtime;

namespace Project_DB.Pages
{
    [BindProperties(SupportsGet = true)]
    public class DeliveryProfileModel : PageModel
    {
        
        public int ID2 { get; set; }
        public Driver deliveryinfo { get; set; }
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source =Tamer; Initial Catalog = Project 2.0; Integrated Security = True";
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
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    string query_get_orders = "select Destination, city from Orders as o inner join Delivery as d on o.delivery_id = d.delivery_id where d.delivery_id = @Id and Destination is not null ";
                    using (SqlCommand cmd = new SqlCommand (query_get_orders, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", ID2);
                        using (SqlDataReader reader = cmd.ExecuteReader ())
                        {
                            if (reader.Read())
                            {
                                deliveryinfo.destination = reader["Destination"].ToString();
                                deliveryinfo.city = reader["city"].ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }


    }
}
