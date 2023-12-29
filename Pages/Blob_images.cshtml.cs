using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class Blob_imagesModel : PageModel
    {
        public byte[] Image { get; set; }
        public async Task OnGetAsync()
        {
            string connectionString = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT image_data FROM image_test WHERE image_name = 'grilled fish'";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        const int bufferSize = 4096; // You can adjust the buffer size as needed
                        long bytesRead;
                        long fieldOffset = 0;
                        long streamLength = reader.GetBytes(0, fieldOffset, null, 0, 0); // Get the length of the field

                        using (MemoryStream ms = new MemoryStream())
                        {
                            byte[] buffer = new byte[bufferSize];

                            while ((bytesRead = reader.GetBytes(0, fieldOffset, buffer, 0, bufferSize)) > 0)
                            {
                                await ms.WriteAsync(buffer, 0, (int)bytesRead);
                                fieldOffset += bytesRead;
                            }

                            Image = ms.ToArray();
                        }
                    }
                }
            }
        }
    }
}