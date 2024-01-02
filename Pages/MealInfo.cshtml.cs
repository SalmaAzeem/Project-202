using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
namespace Project_DB.Pages
{
    public class MealInfoModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string id_minishop { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Minishop_name { get; set; }
        [BindProperty(SupportsGet = true)]
        public double Minishop_price { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Minishop_identifier { get; set; }
        [BindProperty(SupportsGet = true)]
        public int flag { get; set; }

        public void OnGet(string id, string identifier)
        {
            Minishop_identifier = identifier;

            id_minishop = id;
            string connectionString = "Data Source=Salma_Sherif;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();

            string query_minishop = "select Food_cans, prices from MiniShop where minishop_id = @minishop_id";
            string query_menu = "select Meal_Name, price from Meals where meal_id = @minishop_id";





            try
            {

                if (Minishop_identifier == "Menu")
                {
                    flag = 0;
                    SqlCommand query_minishop_Command = new SqlCommand(query_menu, con);
                    query_minishop_Command.Parameters.AddWithValue("@minishop_id", id);
                    SqlDataReader reader = query_minishop_Command.ExecuteReader();
                    while (reader.Read())
                    {

                        if (reader[0].ToString() != null && reader[1].ToString() != null)
                        {
                            Minishop_name = reader[0].ToString();


                            Minishop_price = Convert.ToDouble(reader[1]);


                        }

                    }

                }
                else if (Minishop_identifier == "MiniShop")
                {
                    flag = 1;
                    SqlCommand query_minishop_Command = new SqlCommand(query_minishop, con);
                    query_minishop_Command.Parameters.AddWithValue("@minishop_id", id);
                    SqlDataReader reader = query_minishop_Command.ExecuteReader();
                    while (reader.Read())
                    {

                        if (reader[0].ToString() != null && reader[1].ToString() != null)
                        {
                            Minishop_name = reader[0].ToString();


                            Minishop_price = Convert.ToDouble(reader[1]);


                        }

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
        [ValidateAntiForgeryToken]
        public IActionResult OnPostUpdate()
        {
            id_minishop = Request.Form["id_minishop"];
            Minishop_identifier = Request.Form["Minishop_identifier"];
            Minishop_name = Request.Form["Minishop_name"];
            flag = Convert.ToInt32(Request.Form["flag"]);
            Minishop_price = Convert.ToDouble(Request.Form["Minishop_price"]);

            Console.WriteLine(id_minishop);
            Console.WriteLine(Minishop_name);
            Console.WriteLine(Minishop_price);
            Console.WriteLine(flag);

            string connectionString = "Data Source=Salma_Sherif;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query_minishop = "select Food_cans, prices from MiniShop where minishop_id = @minishop_id";
            string query_menu = "select Meal_Name, price from Meals where meal_id = @minishop_id";
            try
            {

                if (Minishop_identifier == "Menu")
                {
                    flag = 0;
                    SqlCommand query_minishop_Command = new SqlCommand(query_menu, con);
                    query_minishop_Command.Parameters.AddWithValue("@minishop_id", id_minishop);
                    SqlDataReader reader = query_minishop_Command.ExecuteReader();
                    while (reader.Read())
                    {

                        if (reader[0].ToString() != null && reader[1].ToString() != null)
                        {
                            Minishop_name = reader[0].ToString();


                            Minishop_price = Convert.ToDouble(reader[1]);


                        }

                    }

                }
                else if (Minishop_identifier == "MiniShop")
                {
                    flag = 1;
                    SqlCommand query_minishop_Command = new SqlCommand(query_minishop, con);
                    query_minishop_Command.Parameters.AddWithValue("@minishop_id", id_minishop);
                    SqlDataReader reader = query_minishop_Command.ExecuteReader();
                    while (reader.Read())
                    {

                        if (reader[0].ToString() != null && reader[1].ToString() != null)
                        {
                            Minishop_name = reader[0].ToString();


                            Minishop_price = Convert.ToDouble(reader[1]);


                        }

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





            string query_cart = "INSERT INTO [dbo].[Cart]([item_ID],[item_name],[flag],[item_price],[item_image])VALUES(@id_minishop, @Minishop_name,@flag, @Minishop_price,null)";
            SqlCommand insertCommand = new SqlCommand(query_cart, con);
            insertCommand.Parameters.AddWithValue("@id_minishop", id_minishop);
            insertCommand.Parameters.AddWithValue("@Minishop_name", Minishop_name);
            insertCommand.Parameters.AddWithValue("@flag", flag);
            insertCommand.Parameters.AddWithValue("@Minishop_price", Minishop_price);

            try
            {
                con.Open();
                insertCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return RedirectToPage("/MealInfo", new { id_minishop = id_minishop, Minishop_identifier = Minishop_identifier });


        }


    }
}