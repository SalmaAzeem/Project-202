using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Project_DB.Pages
{
    public class Blob_imagesModel : PageModel
    {
        public byte[] Image { get; set; }
        public List<string> ids { get; set; } = new List<string>() {"4", "6", "9", "12", "15", "18", "21", "27", "30", "33", "36", "39", "42"};
        public List<string> Images { get; set; } = new List<string>();
        public async Task OnGetAsync()
        {
            string connectionString = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query4 = "select Cooker_Image from Cooker where Cooker_id = @Id";
                using (SqlCommand cmd_4 = new SqlCommand(query4, connection))
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

                                    Image = ms.ToArray();
                                    Images.Add(Convert.ToBase64String(Image));
                                    //Cooker_image = ms.ToArray();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}