using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    [BindProperties]
    public class Cooker_interfaceModel : PageModel
    {
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string phone_number { get; set; }
		public void OnGet()
		{
			string connection = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
			using (SqlConnection con = new SqlConnection(connection))
			{
				try
				{
					con.Open();
					Id = 4;
					string query = "select UserName, Email, Phone_Number from Userr where ID = @Id";
					using (SqlCommand cmd = new SqlCommand(query, con))
					{
						cmd.Parameters.AddWithValue("@Id", Id);
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								UserName = reader["UserName"].ToString();
								Email = reader["Email"].ToString();
								phone_number = reader["Phone_Number"].ToString();
							}
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"An error occurred: {ex.Message}");
				}
				finally
				{
					con.Close();
				}
			}
		}
	}
}
