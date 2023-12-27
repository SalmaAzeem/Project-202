using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    [BindProperties(SupportsGet = true)]
    public class Cooker_interfaceModel : PageModel
    {
		public string CookerGender { get; set; }
		public int CookerID { get; set; }
        public int Rating_CookerID { get; set; }
		public string CookerName { get; set; }
		public string CookerEmail { get; set; }
		public int CookerPhone { get; set; }
		public int Rating {  get; set; }
		public List<string> Meals { get; set; } = new List<string>();
        //public string Image_path { get; set; }
        public void OnGet(string name, string email, string phone, string id)
        {
            CookerName = name;
            CookerEmail = email;
            CookerPhone = Convert.ToInt32(phone);
            CookerID = Convert.ToInt32(id);
            Rating_CookerID = Convert.ToInt32(id);
            string connection = "Data Source=Tamer;Initial Catalog=Project 2.0;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    //string query = "SELECT Gender FROM Cooker WHERE Cooker_id = @CookerID";
                    //using (SqlCommand cmd = new SqlCommand(query, con))
                    //{
                    //    cmd.Parameters.AddWithValue("@CookerID", CookerID);
                    //    SqlDataReader reader = cmd.ExecuteReader();

                    //    if (reader.Read())
                    //    {
                    //        CookerGender = reader["Gender"].ToString();
                    //    }
                    //}
                    string query2 = "SELECT Meal_Name FROM Meals m INNER JOIN Cooks_Meal cm ON m.meal_id = cm.meal_id WHERE Cooker_id = @CookerID";
                    using (SqlCommand cmd2 = new SqlCommand(query2, con))
                    {
                        cmd2.Parameters.AddWithValue("@CookerID", CookerID);
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
            }
        }

        public void OnGetMeals()
		{

		}
		public void OnPost(int ratingRadio)
		{
			Rating = ratingRadio;

			string connection = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
			SqlConnection con = new SqlConnection(connection);
			con.Open();
			string query = "insert into rating_cooker_two values (@CookerID, @Rating)";
			SqlCommand cmd = new SqlCommand(@query, con);
			try
			{
				cmd.Parameters.AddWithValue("@CookerID", Rating_CookerID);
				cmd.Parameters.AddWithValue("@Rating", ratingRadio);
				cmd.ExecuteNonQuery();
				Console.WriteLine("success");
			}
			catch (Exception ex) { Console.WriteLine(ex.ToString()); }
			finally { con.Close(); }
		}
	}
}
