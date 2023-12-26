using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    [BindProperties]
    public class Cooker_interfaceModel : PageModel
    {
		public string CookerGender { get; set; }
		public int CookerID { get; set; }
		public string CookerName { get; set; }
		public string CookerEmail { get; set; }
		public int CookerPhone { get; set; }
		//public string Image_path { get; set; }
		public void OnGet(string name, string email, string phone, string id)
		{
			CookerName = name;
			CookerEmail = email;
			CookerPhone = Convert.ToInt32(phone);
			CookerID = Convert.ToInt32(id);
			string connection = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
			SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select Gender from Cooker where Cooker_id = @CookerID";
            try
			{
				SqlCommand cmd = new SqlCommand(query, con);
				cmd.Parameters.AddWithValue("@CookerID", CookerID);
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					CookerGender = reader["Gender"].ToString();
				}
				
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occured: {ex.Message}");
			}
			finally { con.Close(); }
			
		}
	}
}
