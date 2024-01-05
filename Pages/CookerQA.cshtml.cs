using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.Data.SqlClient;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Linq;
using System.Data;

namespace Project_DB.Pages
{
    public class CookerQAcshtmlModel : PageModel
    {
       
        [BindProperty(SupportsGet = true)]
        public Cooker cookerinfo { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        
        [BindProperty]
        public IFormFile? image { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {

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

                //string connectionString = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
                string connectionString = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q = "INSERT INTO Cooker" +
                        "(Cooker_id, city,street,Apartment_Number,Description_Cooker,Cooker_Image) VALUES" +
                        "(@Cooker_id, @city,@street,@Apartment_Number,@Description_Cooker,@Cooker_Image)";

                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        cmd.Parameters.AddWithValue("@Cooker_id", ID.ToString());
                        cmd.Parameters.AddWithValue("@city", cookerinfo.city);
                        cmd.Parameters.AddWithValue("@street", cookerinfo.street);
                        cmd.Parameters.AddWithValue("@Apartment_Number", cookerinfo.Apartment_Number);
                        cmd.Parameters.AddWithValue("@Description_Cooker", cookerinfo.Description);
                        cmd.Parameters.AddWithValue("@Cooker_Image", 00100);


                        cmd.ExecuteNonQuery();
                    }
                    if (image != null && IsImage(image))
                    {
                        byte[] imageData = ProcessImage(image);
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string updateQuery = "UPDATE Cooker SET Cooker_Image = @ImageData WHERE Cooker_id = @Cooker_id;";

                            using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                            {
                                cmd.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = imageData;
                                cmd.Parameters.AddWithValue("@Cooker_id", ID);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Not an image");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return RedirectToPage("/CookerProfile", new { ID2 = ID });

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

        private byte[] ProcessImage(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                using (var imageSharp = Image.Load(memoryStream.ToArray()))
                {
                    // Resize the image if needed
                    imageSharp.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new Size(800, 600), // Adjust the size as needed
                        Mode = ResizeMode.Max
                    }));

                    using (var outputStream = new MemoryStream())
                    {
                        imageSharp.Save(outputStream, new JpegEncoder());
                        return outputStream.ToArray();
                    }
                }
            }
        }

    }

}

