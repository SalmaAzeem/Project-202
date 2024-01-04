using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SixLabors.ImageSharp.Formats.Jpeg;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Project_DB.Pages
{
    public class new_tryModel : PageModel
    {
        public SqlConnection? Con { get; set; }
        public string? type { get; set; }
        [BindProperty]
        public string? name { get; set; }
        [BindProperty]
        public string? category { get; set; }
        [BindProperty]
        public int price { get; set; }
        [BindProperty]
        public List<IFormFile>? images { get; set; }
        [BindProperty]
        public string? description { get; set; }
        int id { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostTry()
        {
            int id = 0;

            string conStr = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            using (SqlConnection Con = new SqlConnection(conStr))
            {
                Con.Open();

                string insertProductImageQuery = "INSERT INTO try (id, image_data) VALUES (@id, @ImageData);";

                try
                {
                    if (images != null && images.Any())
                    {
                        foreach (var image in images)
                        {
                            if (image.Length > 0 && IsImage(image))
                            {
                                byte[] imageData = null;
                                using (var memoryStream = new MemoryStream())
                                {
                                    image.CopyTo(memoryStream);
                                    using (var imageSharp = Image.Load(memoryStream.ToArray()))
                                    {
                                        // Resize the image if needed
                                        imageSharp.Mutate(x => x.Resize(new ResizeOptions
                                        {
                                            Size = new Size(800, 600),
                                            Mode = ResizeMode.Max
                                        }));

                                        using (var outputStream = new MemoryStream())
                                        {
                                            imageSharp.Save(outputStream, new JpegEncoder());
                                            imageData = outputStream.ToArray();
                                        }
                                    }
                                }

                                using (SqlCommand imageCmd = new SqlCommand(insertProductImageQuery, Con))
                                {
                                    imageCmd.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = imageData;
                                    imageCmd.Parameters.AddWithValue("@id", id);
                                    imageCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // Handle the case where the uploaded file is not an image
                            }
                        }
                    }

                    Console.WriteLine("AddProduct method ended...");
                    return RedirectToPage("/MealInfo");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return RedirectToPage("/MealInfo");
                }
            }
        }

        private bool IsImage(IFormFile file)
        {
            try
            {
                using (var imageStream = file.OpenReadStream())
                {
                    Image.Load(imageStream);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
