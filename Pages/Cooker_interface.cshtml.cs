using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    [BindProperties]
    public class Cooker_interfaceModel : PageModel
    {
        public int id { get; set; }
        public void OnGet()
        {
        }
        public void OnPost() {
            string connection = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();


		}
    }
}
