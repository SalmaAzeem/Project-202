using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class MenuModel : PageModel
    {
        public int Main_Count { get; set; }
        public string Meal_name { get; set; }
        public double price { get; set; }
        public string Ingredient { get; set; }

        public List<string> Main_Courses_Meal_names = new List<string>();

        public List<string> Breakfast_Meal_names = new List<string>();

        public List<string> Desserts_Meal_names = new List<string>();

        public List<string> Appetizers_Meal_names = new List<string>();

        public List<string> Others_Meal_names = new List<string>();

        public List<string> Main_Courses_Meal_ingredients = new List<string>();

        public List<string> Breakfast_Meal_ingredients = new List<string>();

        public List<string> Desserts_Meal_ingredients = new List<string>();

        public List<string> Appetizers_Meal_ingredients = new List<string>();

        public List<string> Others_Meal_ingredients = new List<string>();

        public List<double> prices_Breakfast = new List<double>();

        public List<double> prices_Desserts = new List<double>();

        public List<double> prices_Main_Courses = new List<double>();

        public List<double> prices_Appetizers = new List<double>();

        public List<double> prices_Others = new List<double>();



        public void OnGet()
        {
            string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query_Main_Courses = "select Meal_Name, Ingredients, price from Meals where category_id = 6";


            try
            {

                SqlCommand Main_Courses_Command = new SqlCommand(query_Main_Courses, con);
                SqlDataReader reader = Main_Courses_Command.ExecuteReader();
                while (reader.Read())
                {

                    if (reader[0].ToString() != null && reader[1].ToString() != null && reader[2].ToString() != null)
                    {
                        Meal_name = reader[0].ToString();
                        Ingredient = reader[1].ToString();
                        price = Convert.ToDouble(reader[2]);
                        Main_Courses_Meal_names.Add(Meal_name);
                        prices_Main_Courses.Add(price);
                        Main_Courses_Meal_ingredients.Add(Ingredient);
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

            con.Open();
            string query_Breakfast = "select Meal_Name, Ingredients, price from Meals where category_id = 4";

            try
            {
                SqlCommand Breakfast_Command = new SqlCommand(query_Breakfast, con);
                SqlDataReader reader_Breakfast = Breakfast_Command.ExecuteReader();


                while (reader_Breakfast.Read())
                {

                    if (reader_Breakfast[0].ToString() != null && reader_Breakfast[1].ToString() != null && reader_Breakfast[2].ToString() != null)
                    {
                        Meal_name = reader_Breakfast[0].ToString();
                        Ingredient = reader_Breakfast[1].ToString();
                        price = Convert.ToDouble(reader_Breakfast[2]);
                        Breakfast_Meal_names.Add(Meal_name);
                        prices_Breakfast.Add(price);
                        Breakfast_Meal_ingredients.Add(Ingredient);
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

            con.Open();
            string query_Appetizers = "select Meal_Name, Ingredients, price from Meals where category_id = 5";

            try
            {

                SqlCommand Appetizers_Command = new SqlCommand(query_Appetizers, con);
                SqlDataReader reader_Appetizers = Appetizers_Command.ExecuteReader();

                while (reader_Appetizers.Read())
                {

                    if (reader_Appetizers[0].ToString() != null && reader_Appetizers[1].ToString() != null && reader_Appetizers[2].ToString() != null)
                    {
                        Meal_name = reader_Appetizers[0].ToString();
                        Ingredient = reader_Appetizers[1].ToString();
                        price = Convert.ToDouble(reader_Appetizers[2]);
                        Appetizers_Meal_names.Add(Meal_name);
                        prices_Appetizers.Add(price);
                        Appetizers_Meal_ingredients.Add(Ingredient);
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

            con.Open();
            string query_Desserts = "select Meal_Name, Ingredients, price from Meals where category_id = 3";

            try
            {

                SqlCommand Desserts_Command = new SqlCommand(query_Desserts, con);
                SqlDataReader reader_Desserts = Desserts_Command.ExecuteReader();

                while (reader_Desserts.Read())
                {

                    if (reader_Desserts[0].ToString() != null && reader_Desserts[1].ToString() != null && reader_Desserts[2].ToString() != null)
                    {
                        Meal_name = reader_Desserts[0].ToString();
                        Ingredient = reader_Desserts[1].ToString();
                        price = Convert.ToDouble(reader_Desserts[2]);
                        Desserts_Meal_names.Add(Meal_name);
                        prices_Desserts.Add(price);
                        Desserts_Meal_ingredients.Add(Ingredient);
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


            con.Open();
            string query_others = "select Meal_Name, Ingredients, price from Meals where category_id not in (3, 4, 5, 6)";

            try
            {

                SqlCommand Others_Command = new SqlCommand(query_others, con);
                SqlDataReader reader_Others= Others_Command.ExecuteReader();

                while (reader_Others.Read())
                {

                    if (reader_Others[0].ToString() != null && reader_Others[1].ToString() != null && reader_Others[2].ToString() != null)
                    {
                        Meal_name = reader_Others[0].ToString();
                        Ingredient = reader_Others[1].ToString();
                        price = Convert.ToDouble(reader_Others[2]);
                        Others_Meal_names.Add(Meal_name);
                        prices_Others.Add(price);
                        Others_Meal_ingredients.Add(Ingredient);
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
