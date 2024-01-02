using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class CartModel : PageModel
    {
        public string id_cart { get; set; }
        public string my_identifier { get; set; }
        public List<string> identifiers { get; set; } = new List<string>();
        public List<string> ids_Cart { get; set; } = new List<string>();

        public List<string> Meal_name = new List<string>();
        public List<double> prices = new List<double>();
        

        [BindProperty(SupportsGet = true)]
        public int Mealcount { get; set; }

        public void OnGet(string id, string identifier)
        {
            id_cart = id;
            ids_Cart.Add(id_cart);
            my_identifier = identifier;
            identifiers.Add(my_identifier);

            string connectionString = "Data Source=Salma_Sherif;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            

            try
            {
                Mealcount = ids_Cart.Count; ;
                Console.WriteLine("Mealcount is ", Mealcount);
                Console.WriteLine("blaaa ", ids_Cart[0]);

                //for (int i = 0; i < Mealcount; i++) {
                    string query_Menu = "select Meal_Name, price from Meals where meal_id = " + ids_Cart[0];
                    SqlCommand cmd_Menu = new SqlCommand(query_Menu, con);
                    SqlDataReader reader = cmd_Menu.ExecuteReader();

                    while (reader.Read())
                    {
                        Meal_name.Add(reader[0].ToString());
                        prices.Add(Convert.ToDouble(reader[1]));
                    }

                //}
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
