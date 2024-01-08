//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.Data;
//using System.Data.SqlClient;

//namespace Project_DB.Pages
//{
//    public class PaymentModel : PageModel
//    {
//        public List<string> Meal_name = new List<string>();
//        public List<double> prices = new List<double>();

//        [BindProperty(SupportsGet = true)]
//        public int Mealcount { get; set; }

//        [BindProperty(SupportsGet = true)]
//        public double total_price { get; set; }

//        [BindProperty(SupportsGet = true)]
//        public double total { get; set; }

//        [BindProperty(SupportsGet = true)]
//        public double shiping { get; set; }

//        [BindProperty(SupportsGet = true)]
//        public string name { get; set; }

//        [BindProperty(SupportsGet = true)]
//        public string address { get; set; }

//        [BindProperty(SupportsGet = true)]
//        public string phone { get; set; }

//        [BindProperty(SupportsGet = true)]
//        public int appartement { get; set; }

//        [BindProperty(SupportsGet = true)]
//        public int orderscount { get; set; }

//        [BindProperty(SupportsGet = true)]
//        public int result2 { get; set; }


//        public void OnGet()
//        {
//            var userId = HttpContext.Session.GetString("UserId");

//            //string connectionString = "Data Source= Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
//            string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
//            SqlConnection con = new SqlConnection(connectionString);
//            con.Open();


//            try
//            {

//                string query_count = "select sum(item_price) from Cart group by item_price";
//                string query_Menu = "select * from Cart";
//                string queryc = "SELECT COUNT(*) FROM Cart";
//                //string queryselect_user_data = $"select UserName, city, street,apartment_number, Phone_Number from Userr , Customer where customer_id = ID and customer_id = {userId}";
//                string queryselect_username = "select UserName from Userr , Customer where customer_id = ID and customer_id = 2";
//                string queryselect_address = "select  city + '-' + street AS address from Userr , Customer where customer_id = ID and customer_id = 2";
//                string queryselect_appartement = "select  apartment_number from Userr , Customer where customer_id = ID and customer_id = 2";
//                string queryselect_phone = "select Phone_Number from Userr , Customer where customer_id = ID and customer_id = 2";


//                SqlCommand cmd_Menu = new SqlCommand(query_Menu, con);
//                SqlCommand cmd_Count = new SqlCommand(query_count, con);
//                SqlCommand cmdcnum = new SqlCommand(queryc, con);
//                SqlCommand cmdcselect_username = new SqlCommand(queryselect_username, con);
//                SqlCommand cmdcselect_address = new SqlCommand(queryselect_address, con);
//                SqlCommand cmdcselect_appartement = new SqlCommand(queryselect_appartement, con);
//                SqlCommand cmdcselect_phone = new SqlCommand(queryselect_phone, con);




//                SqlDataReader reader = cmd_Menu.ExecuteReader();
//                while (reader.Read())
//                {
//                    Meal_name.Add(reader[1].ToString());
//                    prices.Add(Convert.ToDouble(reader[3]));
//                    total_price += Convert.ToDouble(reader[3]);
//                    Console.WriteLine(total_price.ToString());
//                }
//                reader.Close();
//                Mealcount = (int)cmdcnum.ExecuteScalar();
//                name = (string)cmdcselect_username.ExecuteScalar();
//                address = (string)cmdcselect_address.ExecuteScalar();
//                appartement = (int)cmdcselect_appartement.ExecuteScalar();
//                phone = (string)cmdcselect_phone.ExecuteScalar();
//                Mealcount = (int)cmdcnum.ExecuteScalar();
//            }
//            catch (SqlException ex)
//            {
//                Console.WriteLine(ex.ToString());
//            }
//            finally
//            {
//                if (total_price == 0)
//                {
//                    shiping = 0;
//                }
//                else
//                {
//                    shiping = 2.99;
//                }
//                total = shiping + total_price;
//                con.Close();
//            }

//            SqlConnection con2 = new SqlConnection(connectionString);

//            string deleteQuery = "DELETE FROM Cart";
//            string querycount_order = "SELECT COUNT(*) FROM Orders";
//            string querycount_invoice = "SELECT COUNT(*) FROM Invoices";
//            string query_order_add = "INSERT INTO [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id]) VALUES (@order_id, 'Cashh', 'Not Delivered', @customer_id)";
//            string query_invoice_add = "INSERT INTO [dbo].[Invoices]([invoice_id],[order_id],[total_price])VALUES(@invoiceid,@order_id2,@total_price2)";

//            try
//            {
//                con2.Open();

//                SqlCommand deleteCmd = new SqlCommand(deleteQuery, con2);
//                SqlCommand cmdcount_order = new SqlCommand(querycount_order, con2);
//                int result = (int)cmdcount_order.ExecuteScalar();
//                SqlCommand cmdcount_invoice = new SqlCommand(querycount_invoice, con2);
//                result2 = (int)cmdcount_invoice.ExecuteScalar() + 1;
//                SqlCommand insertCommand = new SqlCommand(query_order_add, con2);
//                SqlCommand insertCommandinvoice = new SqlCommand(query_invoice_add, con2);

//                insertCommand.Parameters.AddWithValue("@order_id", result +1);
//                //insertCommand.Parameters.AddWithValue("@payment_type", "Cash");
//                insertCommand.Parameters.AddWithValue("@customer_id", 2);  //userId
//                insertCommand.ExecuteNonQuery();

//                insertCommandinvoice.Parameters.AddWithValue("@invoiceid", result2);
//                insertCommandinvoice.Parameters.AddWithValue("@order_id2", result + 1);
//                insertCommandinvoice.Parameters.AddWithValue("@total_price2", total);
//                insertCommandinvoice.ExecuteNonQuery();
//                deleteCmd.ExecuteNonQuery();
//            }
//            catch (SqlException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {
//                if (con2.State == ConnectionState.Open)
//                {
//                    con2.Close();
//                }
//            }
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class PaymentModel : PageModel
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


        public void OnGet()
        {
            var userId = HttpContext.Session.GetString("UserId");

            //string connectionString = "Data Source=Salma_Sherif;Initial Catalog=\"Project 2.0\";Integrated Security=True"
            //string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True"; 
            string connectionString = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True"; 
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            try
            {

                string query_count = "select sum(item_price) from Cart group by item_price";
                string query_Menu = "select * from Cart";
                string queryc = "SELECT COUNT(*) FROM Cart";
                //string queryselect_user_data = $"select UserName, city, street,apartment_number, Phone_Number from Userr , Customer where customer_id = ID and customer_id = {userId}";
                string queryselect_username = "select UserName from Userr , Customer where customer_id = ID and customer_id = 2";
                string queryselect_address = "select  city + '-' + street AS address from Userr , Customer where customer_id = ID and customer_id = 2";
                string queryselect_appartement = "select  apartment_number from Userr , Customer where customer_id = ID and customer_id = 2";
                string queryselect_phone = "select Phone_Number from Userr , Customer where customer_id = ID and customer_id = 2";


                SqlCommand cmd_Menu = new SqlCommand(query_Menu, con);
                SqlCommand cmd_Count = new SqlCommand(query_count, con);
                SqlCommand cmdcnum = new SqlCommand(queryc, con);
                SqlCommand cmdcselect_username = new SqlCommand(queryselect_username, con);
                SqlCommand cmdcselect_address = new SqlCommand(queryselect_address, con);
                SqlCommand cmdcselect_appartement = new SqlCommand(queryselect_appartement, con);
                SqlCommand cmdcselect_phone = new SqlCommand(queryselect_phone, con);




                SqlDataReader reader = cmd_Menu.ExecuteReader();
                while (reader.Read())
                {
                    Meal_name.Add(reader[1].ToString());
                    prices.Add(Convert.ToDouble(reader[3]));
                    total_price += Convert.ToDouble(reader[3]);
                    Console.WriteLine(total_price.ToString());
                }
                reader.Close();
                Mealcount = (int)cmdcnum.ExecuteScalar();
                name = (string)cmdcselect_username.ExecuteScalar();
                address = (string)cmdcselect_address.ExecuteScalar();
                appartement = (int)cmdcselect_appartement.ExecuteScalar();
                phone = (string)cmdcselect_phone.ExecuteScalar();
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

            SqlConnection con2 = new SqlConnection(connectionString);

            string deleteQuery = "DELETE FROM Cart";
            string querycount_order = "SELECT COUNT(*) FROM Orders";
            string querycount_invoice = "SELECT COUNT(*) FROM Invoices";
            string query_order_add = "INSERT INTO [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id]) VALUES (@order_id, 'Cashh', 'Not Delivered', @customer_id)";
            string query_invoice_add = "INSERT INTO [dbo].[Invoices]([invoice_id],[order_id],[total_price])VALUES(@invoiceid,@order_id2,@total_price2)";

            try
            {
                con2.Open();

                SqlCommand deleteCmd = new SqlCommand(deleteQuery, con2);
                SqlCommand cmdcount_order = new SqlCommand(querycount_order, con2);
                int result = (int)cmdcount_order.ExecuteScalar();
                SqlCommand cmdcount_invoice = new SqlCommand(querycount_invoice, con2);
                result2 = (int)cmdcount_invoice.ExecuteScalar() + 1;
                SqlCommand insertCommand = new SqlCommand(query_order_add, con2);
                SqlCommand insertCommandinvoice = new SqlCommand(query_invoice_add, con2);

                insertCommand.Parameters.AddWithValue("@order_id", result + 1);
                //insertCommand.Parameters.AddWithValue("@payment_type", "Cash");
                insertCommand.Parameters.AddWithValue("@customer_id", 2);  //userId
                insertCommand.ExecuteNonQuery();

                insertCommandinvoice.Parameters.AddWithValue("@invoiceid", result2);
                insertCommandinvoice.Parameters.AddWithValue("@order_id2", result + 1);
                insertCommandinvoice.Parameters.AddWithValue("@total_price2", total);
                insertCommandinvoice.ExecuteNonQuery();
                deleteCmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con2.State == ConnectionState.Open)
                {
                    con2.Close();
                }
            }
        }
    }
}