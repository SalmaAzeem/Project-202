using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Project_DB.Pages
{
    public class CartModel : PageModel
    {
        public List<string> identifiers { get; set; } = new List<string>();
        public List<string> ids_Cart { get; set; } = new List<string>();

        public List<string> Meal_name = new List<string>();
        public List<double> prices = new List<double>();
        public List<double> quantities = new List<double>();
        public List<int> flags = new List<int>();



        [BindProperty(SupportsGet = true)]
        public int Mealcount { get; set; }
        [BindProperty(SupportsGet = true)]

        public double total_price { get; set; }
        [BindProperty(SupportsGet = true)]

        public double total { get; set; }
        [BindProperty(SupportsGet = true)]
        public double shiping { get; set; }
        [BindProperty(SupportsGet = true)]
        public string promocodestring { get; set; }

        [BindProperty(SupportsGet = true)]
        public int discount { get; set; }

        [BindProperty(SupportsGet = true)]
        public int count { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? city { get; set; }

        [BindProperty(SupportsGet = true)]
        public double price { get; set; }
        public List<byte[]> Images_cart_MiniShop { get; set; } = new List<byte[]>();
        public List<byte[]> Images_cart_Menu { get; set; } = new List<byte[]>();

        public void OnGet(string identifier)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            string connectionString = "Data Source=Salma_Sherif;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            //string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                try
                {
                    string query_count = "select sum(item_price) from Cart group by item_price";
                    string query_Menu = "select * from Cart";
                    string queryc = "SELECT COUNT(*) FROM Cart";
                    string validationcity = "select count(*) from Shipping where city = @city";
                    string cityprice = "select * from Shipping where city = @cityy";
                    string queryselect_city = $"select * from Customer where customer_id = {userId.Value}";

                    SqlCommand cmd_Menu = new SqlCommand(query_Menu, con);
                    SqlCommand cmd_Count = new SqlCommand(query_count, con);
                    SqlCommand cmdcnum = new SqlCommand(queryc, con);
                    SqlCommand cmdcselect_city = new SqlCommand(queryselect_city, con);
                    SqlDataReader reader = cmd_Menu.ExecuteReader();

                    while (reader.Read())
                    {
                        ids_Cart.Add(reader[0].ToString());
                        Meal_name.Add(reader[1].ToString());
                        prices.Add(Convert.ToDouble(reader[3]) * Convert.ToDouble(reader[5]));
                        flags.Add(Convert.ToInt32(reader[2]));
                        quantities.Add(Convert.ToDouble(reader[5]));
                        total_price += Convert.ToDouble(reader[3]) * Convert.ToDouble(reader[5]);
                    }

                    reader.Close();

                    Mealcount = (int)cmdcnum.ExecuteScalar();

                    SqlDataReader reader2 = cmdcselect_city.ExecuteReader();
                    while (reader2.Read())
                    {
                        city = reader2[1].ToString();
                    }
                    reader2.Close();

                    using (SqlCommand cmd = new SqlCommand(validationcity, con))
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                        int counter = Convert.ToInt32(cmd.ExecuteScalar());

                        if (counter == 0)
                        {
                            shiping = 2.99;  // cost
                        }
                        else if (counter == 1)
                        {
                            SqlCommand cmdprice = new SqlCommand(cityprice, con);
                            cmdprice.Parameters.AddWithValue("@cityy", city);
                            SqlDataReader reader3 = cmdprice.ExecuteReader();

                            while (reader3.Read())
                            {
                                price = Convert.ToDouble(reader3[1]);
                            }
                            reader3.Close();
                            shiping = price;
                        }
                        else if (total_price == 0)
                        {
                            shiping = 0;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    total = shiping + total_price;
                    con.Close();
                }
            }
        }


        public IActionResult OnPost()
        {
            string connectionString = "Data Source= Salma_Sherif;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            //string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var error in modelState.Errors)
                        {
                            TempData["ErrorMessage"] = error.ErrorMessage;
                            Console.WriteLine($"Model error: {error.ErrorMessage}");
                        }
                    }
                    return Page();
                }

                string validation = "select count(*) from promo_codes where promo_code = @promocodestring";
                using (SqlCommand cmd = new SqlCommand(validation, con))
                {
                    cmd.Parameters.AddWithValue("@promocodestring", promocodestring);
                    int counter = Convert.ToInt32(cmd.ExecuteScalar());
                    if (counter == 0)
                    {
                        TempData["ErrorMessage"] = "Enter a valid promo code or enter Nah";
                        return Page();
                    }

                    string discountper = "select * from promo_codes where promo_code = @promo";
                    SqlCommand cmddiscountper = new SqlCommand(discountper, con);
                    cmddiscountper.Parameters.AddWithValue("@promo", promocodestring);
                    SqlDataReader reader = cmddiscountper.ExecuteReader();
                    while (reader.Read())
                    {
                        discount = reader.GetInt32(1);
                    }


                }
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

            return RedirectToPage("/Payment", new { discount2 = discount });
        }



        public async Task<IActionResult> OnGetImagesAsync()
        {

            //string connection = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            string connection = "Data Source=Salma_Sherif;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            //string connection = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";


            using (SqlConnection con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                string query4 = "select item_image from Cart where item_id = @Id and flag = 0";
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
                                    Images_cart_Menu.Add(ms.ToArray());
                                    Console.WriteLine($"Data Size: {ms.ToArray()?.Length} bytes");
                                    //Console.WriteLine(Images_Minishop.Count());
                                    //Cooker_image = ms.ToArray();
                                }
                            }
                        }
                    }
                }
            }

            using (SqlConnection con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                string query5 = "select item_image from Cart where item_id = @Id and flag = 1";
                using (SqlCommand cmd_4 = new SqlCommand(query5, con))
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
                                    Images_cart_MiniShop.Add(ms.ToArray());
                                    Console.WriteLine($"Data Size: {ms.ToArray()?.Length} bytes");
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