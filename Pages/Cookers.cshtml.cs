using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.Data;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    [BindProperties(SupportsGet = true)]
    public class CookersModel : PageModel
    {
        //public Person user = new Person();
        public string name { get; set; }
        public byte[] Cooker_image {  get; set; }
        public List<Cooker> cookers { get; set; } = new List<Cooker>();
        public List<string> ids { get; set; } = new List<string>();        
        public List<string> names { get; set; } = new List<string>();
        public List<byte[]> Images { get; set; } = new List<byte[]>();
        public void OnGet()
        {
            string connection = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "select Cooker_id from Cooker";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ids.Add(reader["Cooker_id"].ToString());
                            }
                        }
                    }
                    string query2 = "SELECT UserName, Email, Phone_Number FROM Userr WHERE ID = @Id";
                    using (SqlCommand cmd_2 = new SqlCommand(query2, conn))
                    {
                        // Define the parameter outside the loop
                        cmd_2.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));

                        foreach (string id in ids)
                        {
                            cmd_2.Parameters["@Id"].Value = id;

                            using (SqlDataReader reader_2 = cmd_2.ExecuteReader())
                            {
                                while (reader_2.Read())
                                {
                                    Cooker cooker = new Cooker();
                                    cooker.Id = Convert.ToInt32(id);
                                    cooker.UserName = reader_2["UserName"].ToString();
                                    cooker.Email = reader_2["Email"].ToString();
                                    cooker.Phone_Number = reader_2["Phone_Number"].ToString();
                                    cookers.Add(cooker);
                                }
                            }
                        }
                    }
                    string query3 = "select Description_Cooker from Cooker where Cooker_id = @Id";
                    using (SqlCommand cmd_3 = new SqlCommand(query3, conn))
                    {
                        cmd_3.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
                        foreach (Cooker Cooker in cookers)
                        {                        
                            cmd_3.Parameters["@Id"].Value = Cooker.Id.ToString();
                            using ( SqlDataReader reader_3 = cmd_3.ExecuteReader()) 
                            {
                                while (reader_3.Read())
                                {
                                    Cooker.Description = reader_3["Description_Cooker"].ToString();
                                }
                            } 
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public async Task<IActionResult> OnGetImagesAsync()
        {
            string connection = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";
            using (SqlConnection con =  new SqlConnection(connection))
            {
                await con.OpenAsync();
                string query4 = "select Cooker_Image from Cooker where Cooker_id = @Id";
                using (SqlCommand cmd_4 = new SqlCommand(query4, con))
                {
                    cmd_4.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
                    foreach (string id in ids)
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
                                    Images.Add(ms.ToArray());
                                    Console.WriteLine(Images.Count());
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