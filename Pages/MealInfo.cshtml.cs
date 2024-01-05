using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using System.Data;
using System.Data.SqlClient;
using Project_DB.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;



namespace Project_DB.Pages
{
    public class MealInfoModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string id_minishop { get; set; }
        public List<string> ids_cart = new List<string>();
        [BindProperty(SupportsGet = true)]
        
        public string Minishop_name { get; set; }
        [BindProperty(SupportsGet = true)]
        public double Minishop_price { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Minishop_identifier { get; set; }
        [BindProperty(SupportsGet = true)]
        public int flag { get; set; }
        public int flag2 { get; set; }
        public byte[] data { get; set; }
        string query4 = "select MinisShop_Image from MiniShop where minishop_id = @Id";
        string query5 = "select Meal_Image from Meals where meal_id = @Id";


        public async Task OnGet(string id, string identifier)
        {
            Minishop_identifier = identifier;
            

            id_minishop = id;

            await PerformDatabaseOperationsAsync(id);
        }

        private async Task PerformDatabaseOperationsAsync(string id)
        {
            string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            //string connectionString = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                await con.OpenAsync();

                string query_minishop = "select Food_cans, prices from MiniShop where minishop_id = @minishop_id";
                string query_menu = "select Meal_Name, price from Meals where meal_id = @minishop_id";
               

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

                Console.WriteLine($"item id is {id}");

                using (SqlDataReader reader_4 = await cmd_4.ExecuteReaderAsync())
                {
                    if (await reader_4.ReadAsync())
                    {
                        if (!reader_4.IsDBNull(0))
                        {
                           
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

            using (SqlConnection con = new SqlConnection(connectionString))
            {
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
                        reader.Close();
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
                        reader.Close();
                    }

                    // Fetch image asynchronously
                    FetchImageFromDatabaseAsync(id_minishop, con, Minishop_identifier == "MiniShop" ? query4 : query5).Wait(); // Wait for completion

                    string query_cart = "INSERT INTO [dbo].[Cart]([item_ID],[item_name],[flag],[item_price],[item_image], [quantity]) VALUES(@id_minishop, @Minishop_name,@flag, @Minishop_price, @ImageData, 1)";
                    SqlCommand insertCommand = new SqlCommand(query_cart, con);

                    string validation = "select count(*) from Cart where item_id = @item_id";
                    using (SqlCommand cmd = new SqlCommand(validation, con))
                    {
                        int quantity;
                        cmd.Parameters.AddWithValue("@item_id", id_minishop);
                        int counter = Convert.ToInt32(cmd.ExecuteScalar());
                        string read_flag = "Select flag from cart where item_id = @item_id";
                        using (SqlCommand read_cmd = new SqlCommand(read_flag, con))
                        {
                            read_cmd.Parameters.AddWithValue("@item_id", id_minishop);
                            flag2  = Convert.ToInt32(read_cmd.ExecuteScalar());
                            Console.WriteLine($"Flag equals{flag}");
                            Console.WriteLine($"Flag2 equals{flag2}");
                        }
                        if (counter > 0 && flag == flag2)
                        {
                            string read_quantity = "Select quantity from cart where item_id = @item_id";
                            using (SqlCommand read_cmd = new SqlCommand(read_quantity, con))
                            {
                                read_cmd.Parameters.AddWithValue("@item_id", id_minishop);
                                quantity = Convert.ToInt32(read_cmd.ExecuteScalar());
                               
                            }
                            string Quantity = "UPDATE Cart SET quantity = @quantity WHERE item_id = @item_id";
                            using (SqlCommand cmd_quantity = new SqlCommand(Quantity, con))
                            {
                                Console.WriteLine($"Quantity is {quantity++}");
                                cmd_quantity.Parameters.AddWithValue("@quantity", quantity++);
                                cmd_quantity.Parameters.AddWithValue("@item_id", id_minishop);
                                cmd_quantity.ExecuteNonQuery();
                            }
                        }
                        else if ((counter > 0 && flag != flag2))
                        {
                            Console.WriteLine("New Item is added");
                            insertCommand.Parameters.AddWithValue("@id_minishop", id_minishop);
                            insertCommand.Parameters.AddWithValue("@Minishop_name", Minishop_name);
                            insertCommand.Parameters.AddWithValue("@flag", flag);
                            insertCommand.Parameters.AddWithValue("@Minishop_price", Minishop_price);
                            if (data != null)
                            {

                                
                                insertCommand.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = data;
                            }
                            insertCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            Console.WriteLine("New Item is added");
                            insertCommand.Parameters.AddWithValue("@id_minishop", id_minishop);
                            insertCommand.Parameters.AddWithValue("@Minishop_name", Minishop_name);
                            insertCommand.Parameters.AddWithValue("@flag", flag);
                            insertCommand.Parameters.AddWithValue("@Minishop_price", Minishop_price);
                            if (data != null)
                            {

                                
                                insertCommand.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = data;
                            }
                            insertCommand.ExecuteNonQuery();

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

            return RedirectToPage("/MealInfo", new { id = id_minishop, identifier = Minishop_identifier });
        }


    }
}