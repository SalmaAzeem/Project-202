using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    [BindProperties]
    public class Cooker_interfaceModel : PageModel
    {
		public List<Person> Cookers = new List<Person>();
		public int CookerId { get; set; }
		public string CookerName { get; set; }
		public string CookerEmail { get; set; }
		public int CookerPhone { get; set; }
		public void OnGet(int cookerid)
		{
			CookerId = cookerid;
			if (TempData.TryGetValue("cookers", out var cookers))
			{
				Cookers = cookers as List<Person>;
			}
			foreach (var cooker in Cookers)
			{
				if (CookerId == cooker.Id)
				{
					CookerName = cooker.UserName;
					CookerEmail = cooker.Email;
					CookerPhone = cooker.Phone_Number;
				}
			}
			//string connection = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
			//using (SqlConnection con = new SqlConnection(connection))
			//{
			//	try
			//	{
			//		con.Open();
			//		string query = "select UserName, Email, Phone_Number from Userr where ID = @CookerID";
			//		using (SqlCommand cmd = new SqlCommand(query, con))
			//		{
   //                     using (SqlDataReader reader = cmd.ExecuteReader())
			//			{

			//			}
   //                 }
			//	}
			//	catch (Exception ex)
			//	{
			//		Console.WriteLine($"An error occurred: {ex.Message}");
			//	}
			//	finally
			//	{
			//		con.Close();
			//	}
			//}
		}
	}
}
