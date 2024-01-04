using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class CartModel : PageModel
    {
        public List<string> identifiers { get; set; } = new List<string>();
        public List<string> ids_Cart { get; set; } = new List<string>();

        public List<string> Meal_name = new List<string>();
        public List<double> prices = new List<double>();



        [BindProperty(SupportsGet = true)]
        public int Mealcount { get; set; }
        [BindProperty(SupportsGet = true)]

        public double total_price { get; set; }
        [BindProperty(SupportsGet = true)]

        public double total { get; set; }
        [BindProperty(SupportsGet = true)]
        public double shiping { get; set; }



        public void OnGet()
        {

            //string connectionString = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            string connectionString = "Data Source= Salma_Sherif;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            try
            {

                string query_count = "select sum(item_price) from Cart group by item_price";
                string query_Menu = "select * from Cart";
                string queryc = "SELECT COUNT(*) FROM Cart";


                SqlCommand cmd_Menu = new SqlCommand(query_Menu, con);
                SqlCommand cmd_Count = new SqlCommand(query_count, con);
                SqlCommand cmdcnum = new SqlCommand(queryc, con);
                SqlDataReader reader = cmd_Menu.ExecuteReader();
                while (reader.Read())
                {
                    Meal_name.Add(reader[1].ToString());
                    prices.Add(Convert.ToDouble(reader[3]));
                    total_price += Convert.ToDouble(reader[3]);
                }
                reader.Close();

                Mealcount = (int)cmdcnum.ExecuteScalar();
                

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (total_price == 0)
                {
                    shiping = 0;
                }
                else
                {
                    shiping = 2.99;
                }
                total = shiping + total_price;
                con.Close();
            }
        }



        public IActionResult OnPost()
        {
            return RedirectToPage("/Payment");
        }



    }
}