using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Project_DB.Pages
{
    public class MiniShopModel : PageModel
    {
        public int Minishop_Count { get; set; }
        public string food_cans_name { get; set; }
        public double price { get; set; }
        public List<string> food_cans_names = new List<string>();

        public List<double> prices = new List<double>();
        public List<string> ids_Minishop { get; set; } = new List<string>();
        public List<byte[]> Images_Minishop { get; set; } = new List<byte[]>();
        public string identifier  { get; set; }
        public void OnGet()
        {
            identifier= "MiniShop";
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


            string querystring = "SELECT Food_cans, prices , minishop_id FROM MiniShop";
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
                            ids_Minishop.Add(reader[2].ToString());

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
        public async Task<IActionResult> OnGetImagesAsync()
        {

            string connection = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";


            using (SqlConnection con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                string query4 = "select MinisShop_Image from MiniShop where minishop_id = @Id";
                using (SqlCommand cmd_4 = new SqlCommand(query4, con))
                {
                    cmd_4.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
                    foreach (string id in ids_Minishop)
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
                                    Images_Minishop.Add(ms.ToArray());
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
