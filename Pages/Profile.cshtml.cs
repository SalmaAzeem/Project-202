using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class ProfileModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int ID2 { get; set; }

        [BindProperty(SupportsGet = true)]
        public Customer customerinfo { get; set; }
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source =Doha-PC; Initial Catalog = Project 2.0; Integrated Security = True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q2 = "SELECT * FROM Userr " +
                                "INNER JOIN Customer ON Userr.ID = Customer.customer_id " +
                                "WHERE Userr.ID = @ID";
                    using (SqlCommand cmd = new SqlCommand(q2, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID2);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            //deliveryinfo.Id = Convert.ToInt32(reader["ID"]);
                            customerinfo.UserName = reader["UserName"].ToString();
                            customerinfo.Email = reader["Email"].ToString();
                            customerinfo.Phone_Number = reader["Phone_Number"].ToString();
                            customerinfo.User_Password = reader["User_Password"].ToString();
                            customerinfo.city = reader["city"].ToString();
                            customerinfo.street = reader["street"].ToString();
                            customerinfo.Apartment_Number = reader["Apartment_Number"].ToString();




                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
