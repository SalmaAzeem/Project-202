using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mime;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
namespace Project_DB.Pages
{
    public class MealInfoModel : PageModel
    {
        public string id_minishop { get; set; }
    
        public string Minishop_name { get; set; }
        public double Minishop_price { get; set; }

        public void OnGet(string id)
        {

            id_minishop = id;
            string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            string query_minishop = "select Food_cans, prices from MiniShop where minishop_id = @minishop_id";


            try
            {

                SqlCommand query_minishop_Command = new SqlCommand(query_minishop, con);
                query_minishop_Command.Parameters.AddWithValue("@minishop_id", id);
                SqlDataReader reader = query_minishop_Command.ExecuteReader();
                while (reader.Read())
                {

                    if (reader[0].ToString() != null && reader[1].ToString() != null)
                    {
                        Minishop_name = reader[0].ToString();
                        Console.WriteLine(Minishop_name);

                        Minishop_price = Convert.ToDouble(reader[1]);
                        Console.WriteLine(Minishop_price);
                 
                    }

                }

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
