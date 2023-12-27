using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Project_DB.Pages
{
    public class MiniShopModel : PageModel
    {
        public int Minishop_Count { get; set; }
        public string food_cans_name { get; set; }
        public double price { get; set; }
        public List<string> food_cans_names = new List<string>();

        public List<double> prices = new List<double>();
        public void OnGet()
        {
            string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT COUNT(*) FROM MiniShop";
            SqlCommand countCommand = new SqlCommand(query, con);

            try
            {
                Minishop_Count = (int)countCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }


            string querystring = "SELECT Food_cans, prices FROM MiniShop";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(querystring, con);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {

                    if (reader[0].ToString() != null)
                    {
                        if (reader[1].ToString() != null)
                        {
                            food_cans_name = reader[0].ToString();
                            price = Convert.ToDouble(reader[1]);
                            food_cans_names.Add(food_cans_name);
                            prices.Add(price);

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

        }
    }

