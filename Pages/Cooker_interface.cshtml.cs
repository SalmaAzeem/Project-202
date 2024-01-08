using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    [BindProperties(SupportsGet = true)]
    public class Cooker_interfaceModel : PageModel
    {
        public int Rating_CookerID { get; set; }
        public Cooker Cooker = new Cooker();
		public int Rating {  get; set; }
        public int Rating_Id { get; set; }
		public List<string> Meals { get; set; } = new List<string>();
        Random random = new Random();

        public void OnGet(string name, string email, string phone, string id)
        {
            Cooker.UserName = name;
            Cooker.Email = email;
            Cooker.Phone_Number = phone;
            Cooker.Id = Convert.ToInt32(id);

            string connection = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            //string connection = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";


            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    string query2 = "SELECT Meal_Name FROM Meals m INNER JOIN Cooks_Meal cm ON m.meal_id = cm.meal_id WHERE Cooker_id = @CookerID";
                    using (SqlCommand cmd2 = new SqlCommand(query2, con))
                    {
                        cmd2.Parameters.AddWithValue("@CookerID", Cooker.Id);
                        SqlDataReader reader2 = cmd2.ExecuteReader();

                        while (reader2.Read())
                        {
                            Meals.Add(reader2["Meal_Name"].ToString());
                            Console.WriteLine($"Added meal: {reader2["Meal_Name"].ToString()}");
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally { con.Close(); }
                try
                {
                    con.Open();
                    string query2 = "select city from Cooker where Cooker_id = @Id";
                    using (SqlCommand cmd2 = new SqlCommand(query2, con))
                    {
                        cmd2.Parameters.AddWithValue("@Id", Cooker.Id);
                        SqlDataReader reader2 = cmd2.ExecuteReader();

                        while (reader2.Read())
                        {
                            Cooker.city = reader2["city"].ToString();
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally { con.Close(); }
            }
        }

        public void OnGetMeals()
		{

		}
		public IActionResult OnPost(int ratingRadio, int id)
		{
			Rating = ratingRadio;
            Rating_CookerID = Convert.ToInt32(id);
            Rating_Id = random.Next();
            string connection = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
			SqlConnection con = new SqlConnection(connection);
			con.Open();
			string query = "insert into Rating_Cooker values (@Rating_Id, @CookerID, @Rating, null)";
			SqlCommand cmd = new SqlCommand(@query, con);
			try
			{
				cmd.Parameters.AddWithValue("@CookerID", Rating_CookerID);
				cmd.Parameters.AddWithValue("@Rating", ratingRadio);
				cmd.Parameters.AddWithValue("@Rating_Id", Rating_Id);
				cmd.ExecuteNonQuery();
				Console.WriteLine("success");
			}
			catch (Exception ex) { Console.WriteLine(ex.ToString()); }
			finally { con.Close(); }
            return RedirectToPage("/Rating_Success", new { rating = Rating });
		}
	}
}
