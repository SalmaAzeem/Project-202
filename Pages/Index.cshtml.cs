using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Project_DB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public int Cookersnum { get; set; }
        public void OnGet()
        {
            string connectionString = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True"; ;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            try
            {

                string queryc = "SELECT COUNT(*) FROM Cooker";

                SqlCommand cmdcnum = new SqlCommand(queryc, con);


                Cookersnum = (int)cmdcnum.ExecuteScalar();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();

            }
        }
    }
}