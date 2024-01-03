using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class CookerProfileModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID2 { get; set; }

        [BindProperty(SupportsGet = true)]
        public Cooker cookerinfo { get; set; }
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q2 = "SELECT * FROM Userr " +
                                "INNER JOIN Cooker ON Userr.ID = Cooker.cooker_id " +
                                "WHERE Userr.ID = @ID";
                    using (SqlCommand cmd = new SqlCommand(q2, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID2);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            //deliveryinfo.Id = Convert.ToInt32(reader["ID"]);
                            cookerinfo.UserName = reader["UserName"].ToString();
                            cookerinfo.Email = reader["Email"].ToString();
                            cookerinfo.Phone_Number = reader["Phone_Number"].ToString();
                            cookerinfo.User_Password = reader["User_Password"].ToString();
                            cookerinfo.city = reader["city"].ToString(); 
                            cookerinfo.street = reader["street"].ToString();
                            cookerinfo.Apartment_Number = reader["Apartment_Number"].ToString();

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
