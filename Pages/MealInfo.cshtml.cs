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
        public byte[] data { get; set; }


        public async Task OnGet(string id, string identifier)
        {
            Minishop_identifier = identifier;
            var userId = HttpContext.Session.GetInt32("UserId");
            Console.WriteLine($"This is the user id {userId}");

            id_minishop = id;

            await PerformDatabaseOperationsAsync(id);
        }

        private async Task PerformDatabaseOperationsAsync(string id)
        {
            string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                await con.OpenAsync();

                string query_minishop = "select Food_cans, prices from MiniShop where minishop_id = @minishop_id";
                string query_menu = "select Meal_Name, price from Meals where meal_id = @minishop_id";
                string query4 = "select MinisShop_Image from MiniShop where minishop_id = @Id";
                string query5 = "select Meal_Image from Meals where meal_id = @Id";

                try
                {
                    if (Minishop_identifier == "Menu")
                    {
                        flag = 0;
                        SqlCommand query_minishop_Command = new SqlCommand(query_menu, con);
                        query_minishop_Command.Parameters.AddWithValue("@minishop_id", id);
                        SqlDataReader reader = query_minishop_Command.ExecuteReader();
                        while (await reader.ReadAsync())
                        {
                            if (reader[0].ToString() != null && reader[1].ToString() != null)
                            {
                                Minishop_name = reader[0].ToString();
                                Minishop_price = Convert.ToDouble(reader[1]);
                            }
                        }
                        reader.Close();

                        // Fetch image asynchronously
                        await FetchImageFromDatabaseAsync(id, con, query5);
                    }
                    else if (Minishop_identifier == "MiniShop")
                    {
                        flag = 1;
                        SqlCommand query_minishop_Command = new SqlCommand(query_minishop, con);
                        query_minishop_Command.Parameters.AddWithValue("@minishop_id", id);
                        SqlDataReader reader = query_minishop_Command.ExecuteReader();
                        while (await reader.ReadAsync())
                        {
                            if (reader[0].ToString() != null && reader[1].ToString() != null)
                            {
                                Minishop_name = reader[0].ToString();
                                Minishop_price = Convert.ToDouble(reader[1]);
                            }
                        }
                        reader.Close();

                        // Fetch image asynchronously
                        await FetchImageFromDatabaseAsync(id, con, query4);
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
        private async Task FetchImageFromDatabaseAsync(string id, SqlConnection con, string query)
        {
            using (SqlCommand cmd_4 = new SqlCommand(query, con))
            {
                cmd_4.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
                cmd_4.Parameters["@Id"].Value = id;

                Console.WriteLine(id);

                using (SqlDataReader reader_4 = await cmd_4.ExecuteReaderAsync())
                {
                    if (await reader_4.ReadAsync())
                    {
                        if (!reader_4.IsDBNull(0))
                        {
                            Console.WriteLine("Ana Null");
                            const int buffersize = 4096;
                            long bytesRead;
                            long field_offset = 0;

                            using (Stream stream = reader_4.GetStream(0))
                            using (MemoryStream ms = new MemoryStream())
                            {
                                await stream.CopyToAsync(ms);
                                data = ms.ToArray();
                            }
                        }
                    }
                }
            }
        }


        //public void OnGet(string id, string identifier)
        //{
        //    Minishop_identifier = identifier;
        //    var userId = HttpContext.Session.GetInt32("UserId");
        //    Console.WriteLine($"This is the user id {userId}");

        //    id_minishop = id;
        //    string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
        //    SqlConnection con = new SqlConnection(connectionString);

        //    con.Open();

        //    string query_minishop = "select Food_cans, prices from MiniShop where minishop_id = @minishop_id";
        //    string query_menu = "select Meal_Name, price from Meals where meal_id = @minishop_id";





        //    try
        //    {

        //        if (Minishop_identifier == "Menu")
        //        {
        //            flag = 0;
        //            SqlCommand query_minishop_Command = new SqlCommand(query_menu, con);
        //            query_minishop_Command.Parameters.AddWithValue("@minishop_id", id);
        //            SqlDataReader reader = query_minishop_Command.ExecuteReader();
        //            while (reader.Read())
        //            {

        //                if (reader[0].ToString() != null && reader[1].ToString() != null)
        //                {
        //                    Minishop_name = reader[0].ToString();


        //                    Minishop_price = Convert.ToDouble(reader[1]);


        //                }

        //            }

        //        }
        //        else if (Minishop_identifier == "MiniShop")
        //        {
        //            flag = 1;
        //            SqlCommand query_minishop_Command = new SqlCommand(query_minishop, con);
        //            query_minishop_Command.Parameters.AddWithValue("@minishop_id", id);
        //            SqlDataReader reader = query_minishop_Command.ExecuteReader();
        //            while (reader.Read())
        //            {

        //                if (reader[0].ToString() != null && reader[1].ToString() != null)
        //                {
        //                    Minishop_name = reader[0].ToString();


        //                    Minishop_price = Convert.ToDouble(reader[1]);


        //                }

        //            }
        //        }


        //        string query4 = "select MinisShop_Image from MiniShop where minishop_id = @Id";


        //            await con.OpenAsync();  // Open the connection asynchronously

        //            using (SqlCommand cmd_4 = new SqlCommand(query4, con))
        //            {
        //                cmd_4.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
        //                cmd_4.Parameters["@Id"].Value = id;

        //                Console.WriteLine(id);

        //                using (SqlDataReader reader_4 = await cmd_4.ExecuteReaderAsync())  // Execute the query asynchronously
        //                {
        //                    if (await reader_4.ReadAsync())  // Read the data asynchronously
        //                    {
        //                        if (!reader_4.IsDBNull(0))
        //                        {
        //                            Console.WriteLine("Ana Null");
        //                            const int buffersize = 4096;
        //                            long bytesRead;
        //                            long field_offset = 0;

        //                            using (MemoryStream ms = new MemoryStream())
        //                            {
        //                                byte[] buffer = new byte[buffersize];

        //                                while ((bytesRead = await reader_4.GetBytesAsync(0, field_offset, buffer, 0, buffersize)) > 0)
        //                                {
        //                                    ms.Write(buffer, 0, (int)bytesRead);
        //                                    field_offset += bytesRead;
        //                                }

        //                                data = ms.ToArray();
        //                            }
        //                        }
        //                    }
        //                }
        //            }





        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }






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

            string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
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
            return RedirectToPage("/MealInfo", new { id = id_minishop, identifier = Minishop_identifier });


        }


    }
}