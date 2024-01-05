using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class CartModel : PageModel
    {
        public List<string> identifiers { get; set; } = new List<string>();
        public List<string> ids_Cart { get; set; } = new List<string>();

        public List<string> Meal_name = new List<string>();
        public List<double> prices = new List<double>();
        public List<double> quantities = new List<double>();



        [BindProperty(SupportsGet = true)]
        public int Mealcount { get; set; }
        [BindProperty(SupportsGet = true)]

        public double total_price { get; set; }
        [BindProperty(SupportsGet = true)]

        public double total { get; set; }
        [BindProperty(SupportsGet = true)]
        public double shiping { get; set; }
        public List<byte[]> Images_cart { get; set; } = new List<byte[]>();



        public void OnGet()
        {

            //string connectionString = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
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
                    ids_Cart.Add(reader[0].ToString());
                    Meal_name.Add(reader[1].ToString());
                    prices.Add(Convert.ToDouble(reader[3]) *Convert.ToDouble(reader[5]));
                    quantities.Add(Convert.ToDouble(reader[5]));
                    total_price += Convert.ToDouble(reader[3])*Convert.ToDouble(reader[5]);
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
            //string connectionString = "Data Source=Salma_Sherif;Initial Catalog=Project 2.0;Integrated Security=True";
            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        con.Open();
            //        string deleteQuery = "DELETE FROM Cart WHERE flag = 0 OR flag = 1;";
            //        using (SqlCommand command = new SqlCommand(deleteQuery, con))
            //        {
            //            int rowsAffected = command.ExecuteNonQuery();
            //            // Optionally, you can check the value of rowsAffected to see how many rows were deleted
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        // Handle exceptions here, for example log the exception
            //        Console.WriteLine(ex.Message);
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }
            //}
            return RedirectToPage("/Payment");
        }



        public async Task<IActionResult> OnGetImagesAsync()
        {

            //string connection = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            string connection = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";


            using (SqlConnection con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                string query4 = "select item_image from Cart where item_id = @Id";
                using (SqlCommand cmd_4 = new SqlCommand(query4, con))
                {
                    cmd_4.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
                    foreach (string id in ids_Cart)
                    {
                        cmd_4.Parameters["@Id"].Value = id;
                        using (SqlDataReader reader_4 = await cmd_4.ExecuteReaderAsync())
                        {
                            if (await reader_4.ReadAsync())
                            {
                                const int buffersize = 4096;
                                long bytesRead;
                                long field_offset = 0; // Reset field_offset for each cooker
                                long stream_length = reader_4.GetBytes(0, field_offset, null, 0, 0);
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    byte[] buffer = new byte[buffersize];
                                    while ((bytesRead = reader_4.GetBytes(0, field_offset, buffer, 0, buffersize)) > 0)
                                    {
                                        await ms.WriteAsync(buffer, 0, (int)bytesRead);
                                        field_offset += bytesRead;
                                    }
                                    Images_cart.Add(ms.ToArray());
                                    //Console.WriteLine(Images_Minishop.Count());
                                    //Cooker_image = ms.ToArray();
                                }
                            }
                        }
                    }
                }
            }
            return new EmptyResult();
        }


    }
}