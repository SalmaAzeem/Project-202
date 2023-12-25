using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
	[BindProperties]
    public class CookersModel : PageModel
    {
		//public Person user = new Person();
		public Person cookers = new Person();
		public void OnGet()
		{
            string connection = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
