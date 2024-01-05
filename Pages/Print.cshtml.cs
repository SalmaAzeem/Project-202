using IronPdf.Razor.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Xml.Linq;

namespace Project_DB.Pages
{
    public class PrintModel : PageModel
    {
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

        [BindProperty(SupportsGet = true)]
        public string name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string address { get; set; }

        [BindProperty(SupportsGet = true)]
        public string phone { get; set; }

        [BindProperty(SupportsGet = true)]
        public int appartement { get; set; }

        [BindProperty(SupportsGet = true)]
        public int orderscount { get; set; }

        [BindProperty(SupportsGet = true)]
        public int result2 { get; set; }

        [BindProperty(SupportsGet = true)]
        public double total2 { get; set; }

        public IActionResult OnGet()
        {


            var userId = HttpContext.Session.GetInt32("UserId");
            //Console.WriteLine(userId);

            //string connectionString = "Data Source= Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            string connectionString = "Data Source= Salma_Sherif;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            try
            {
                string query_count = "select sum(item_price) from Cart group by item_price";
                string query_Menu = "select * from Cart";
                string queryc = "SELECT COUNT(*) FROM Cart";
                string queryselect_username = $"select UserName, city, street,apartment_number, Phone_Number from Userr , Customer where customer_id = ID and customer_id = {userId.Value}";
                string queryselect_address = $"select  city + '-' + street AS address from Userr , Customer where customer_id = ID and customer_id = {userId.Value}";
                string queryselect_appartement = $"select  apartment_number from Userr , Customer where customer_id = ID and customer_id = {userId.Value}";
                string queryselect_phone = $"select Phone_Number from Userr , Customer where customer_id = ID and customer_id = {userId.Value}";
                string querycount_invoice = "SELECT COUNT(*) FROM Invoices";
                

                SqlCommand cmd_Menu = new SqlCommand(query_Menu, con);
                SqlCommand cmd_Count = new SqlCommand(query_count, con);
                SqlCommand cmdcnum = new SqlCommand(queryc, con);
                SqlCommand cmdcselect_username = new SqlCommand(queryselect_username, con);
                SqlCommand cmdcselect_address = new SqlCommand(queryselect_address, con);
                SqlCommand cmdcselect_appartement = new SqlCommand(queryselect_appartement, con);
                SqlCommand cmdcselect_phone = new SqlCommand(queryselect_phone, con);
                SqlCommand cmdcount_invoice = new SqlCommand(querycount_invoice, con);



                SqlDataReader reader = cmd_Menu.ExecuteReader();
                while (reader.Read())
                {
                    Meal_name.Add(reader[1].ToString());
                    prices.Add(Convert.ToDouble(reader[3]));
                    total_price += Convert.ToDouble(reader[3]);
                }
                reader.Close();
                Mealcount = (int)cmdcnum.ExecuteScalar();
                name = (string)cmdcselect_username.ExecuteScalar();
                address = (string)cmdcselect_address.ExecuteScalar();
                appartement = (int)cmdcselect_appartement.ExecuteScalar();
                phone = (string)cmdcselect_phone.ExecuteScalar();
                Mealcount = (int)cmdcnum.ExecuteScalar();
                result2 = (int)cmdcount_invoice.ExecuteScalar() + 1;

              

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            ChromePdfRenderer renderer = new ChromePdfRenderer();
            // Render Razor Page to PDF document
            PdfDocument pdf = renderer.RenderRazorToPdf(this);

            return File(pdf.BinaryData, "application/pdf", $"{userId.Value} Invoice{result2}.pdf");

            // View output PDF on broswer
            return File(pdf.BinaryData, "application/pdf");
        }

    }
}
