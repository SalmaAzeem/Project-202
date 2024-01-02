using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public string id_minishop { get; set; }
    
        public string Minishop_name { get; set; }
        public double Minishop_price { get; set; }
        public string Minishop_identifier { get; set; }
        public int flag { get; set; }

        public void OnGet(string id, string identifier)
        {
            Minishop_identifier = identifier;
            //Console.WriteLine(Minishop_identifier);
            id_minishop = id;
<<<<<<< HEAD
         
            string connectionString = "Data Source=Salma_Sherif;Initial Catalog=\"Project 2.0\";Integrated Security=True";
=======
            string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
>>>>>>> 4a9bcd1db4099c98685b6c6ded32e48f453358af
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();

            string query_minishop = "select Food_cans, prices from MiniShop where minishop_id = @minishop_id";
            string query_menu = "select Meal_Name, price from Meals where meal_id = @minishop_id";
            

           


            try
            {

                if (Minishop_identifier == "Menu")
                {
                    SqlCommand query_minishop_Command = new SqlCommand(query_menu, con);
                    query_minishop_Command.Parameters.AddWithValue("@minishop_id", id);
                    SqlDataReader reader = query_minishop_Command.ExecuteReader();
                    while (reader.Read())
                    {

                        if (reader[0].ToString() != null && reader[1].ToString() != null)
                        {
                            Minishop_name = reader[0].ToString();
                            //Console.WriteLine(Minishop_name);

                            Minishop_price = Convert.ToDouble(reader[1]);
                            //Console.WriteLine(Minishop_price);

                        }

                    }

                }
                else if (Minishop_identifier == "MiniShop")
                {
                    SqlCommand query_minishop_Command = new SqlCommand(query_minishop, con);
                    query_minishop_Command.Parameters.AddWithValue("@minishop_id", id);
                    SqlDataReader reader = query_minishop_Command.ExecuteReader();
                    while (reader.Read())
                    {

                        if (reader[0].ToString() != null && reader[1].ToString() != null)
                        {
                            Minishop_name = reader[0].ToString();
                            //Console.WriteLine(Minishop_name);

                            Minishop_price = Convert.ToDouble(reader[1]);
                            //Console.WriteLine(Minishop_price);

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

        public void OnPost()
        {
            Console.WriteLine(id_minishop);
            if (Minishop_name == "Menu")
            {
                flag = 0;
            }
            else if (Minishop_name == "MiniShop")
            {
                flag = 1;
            }
            string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);


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
     

        }


    }
}
