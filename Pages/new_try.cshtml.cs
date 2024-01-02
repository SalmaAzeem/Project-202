//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.Data.SqlClient;
//using System.Data;

//namespace Project_DB.Pages
//{
    
//    public class new_tryModel : PageModel
//    {
//        public SqlConnection? Con { get; set; }
//        public string? type { get; set; }
//        [BindProperty]
//        public string? name { get; set; }
//        [BindProperty]
//        public string? category { get; set; }
//        [BindProperty]
//        public int price { get; set; }
//        [BindProperty]
//        public List<IFormFile>? images { get; set; }
//        [BindProperty]
//        public string? description { get; set; }
//        public void OnGet()
//        {


//        }


//        public IActionResult OnPostTry()
//        {
//            string conStr = "Data Source=Doha-PC;Initial Catalog=\"Project 2.0\";Integrated Security=True";
//            SqlConnection Con = new SqlConnection(conStr);
//            string insertProductImageQuery = "INSERT INTO Meals (Meal_Image) VALUES (@ImageData);";

//            try
//            {

//                    if ( images != null && images.Any())
//                    {
//                        foreach (var image in images)
//                        {
//                            if (image.Length > 0)
//                            {
//                                byte[] imageData = null;
//                                using (var stream = new MemoryStream())
//                                {
//                                    image.CopyTo(stream);
//                                    imageData = stream.ToArray();
//                                }

//                                using (SqlCommand imageCmd = new SqlCommand(insertProductImageQuery, Con))
//                                {
       
//                                    imageCmd.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = imageData;
//                                    imageCmd.ExecuteNonQuery();
//                                }
//                            }
//                        }
//                    }
                
//                Console.WriteLine("AddProduct method ended...");
//                return RedirectToPage("/ThankYou");
//            }
//            catch (SqlException ex)
//            {
//                Console.WriteLine(ex.Message);
//                return RedirectToPage("/UserInfo");
//            }
//            finally
//            {
//                Con.Close();
//            }
//        }
//        }

//    }

