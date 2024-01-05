using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mime;
using static System.Net.Mime.MediaTypeNames;

namespace Project_DB.Pages
{
    public class MenuModel : PageModel
    {
        public Meal one = new Meal();
  
        public string identifier { get; set; }
 



        public void OnGet()
        {
            identifier = "Menu";
            // string connectionString = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            string connectionString = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
   

            string query_Main_Courses = "select Meal_Name, Ingredients, price, meal_id from Meals where category_id = 6";


            try
            {

                SqlCommand Main_Courses_Command = new SqlCommand(query_Main_Courses, con);
                SqlDataReader reader = Main_Courses_Command.ExecuteReader();

                while (reader.Read())
                {

                    if (reader[0].ToString() != null && reader[1].ToString() != null && reader[2].ToString() != null)
                    {
                        one.Meal_name = reader[0].ToString();
                        one.Ingredient = reader[1].ToString();
                        one.price = Convert.ToDouble(reader[2]);
                        one.Main_Courses_Meal_names.Add(one.Meal_name);
                        one.prices_Main_Courses.Add(one.price);
                        one.Main_Courses_Meal_ingredients.Add(one.Ingredient);
                        one.ids_Main_Courses.Add(reader[3].ToString());
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



            con.Open();
            string query_Breakfast = "select Meal_Name, Ingredients, price, meal_id from Meals where category_id = 4";

            try
            {
                SqlCommand Breakfast_Command = new SqlCommand(query_Breakfast, con);
                SqlDataReader reader_Breakfast = Breakfast_Command.ExecuteReader();


                while (reader_Breakfast.Read())
                {

                    if (reader_Breakfast[0].ToString() != null && reader_Breakfast[1].ToString() != null && reader_Breakfast[2].ToString() != null)
                    {
                        one.Meal_name = reader_Breakfast[0].ToString();
                        one.Ingredient = reader_Breakfast[1].ToString();
                        one.price = Convert.ToDouble(reader_Breakfast[2]);
                        one.Breakfast_Meal_names.Add(one.Meal_name);
                        one.prices_Breakfast.Add(one.price);
                        one.Breakfast_Meal_ingredients.Add(one.Ingredient);
                        one.ids_Breakfast.Add(reader_Breakfast[3].ToString());
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

            con.Open();
            string query_Appetizers = "select Meal_Name, Ingredients, price, meal_id from Meals where category_id = 5";

            try
            {

                SqlCommand Appetizers_Command = new SqlCommand(query_Appetizers, con);
                SqlDataReader reader_Appetizers = Appetizers_Command.ExecuteReader();

                while (reader_Appetizers.Read())
                {

                    if (reader_Appetizers[0].ToString() != null && reader_Appetizers[1].ToString() != null && reader_Appetizers[2].ToString() != null)
                    {
                        one.Meal_name = reader_Appetizers[0].ToString();
                        one.Ingredient = reader_Appetizers[1].ToString();
                        one.price = Convert.ToDouble(reader_Appetizers[2]);
                        one.Appetizers_Meal_names.Add(one.Meal_name);
                        one.prices_Appetizers.Add(one.price);
                        one.Appetizers_Meal_ingredients.Add(one.Ingredient);
                        one.ids_Appetizers.Add(reader_Appetizers[3].ToString());
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

            con.Open();
            string query_Desserts = "select Meal_Name, Ingredients, price , meal_id from Meals where category_id = 3";

            try
            {

                SqlCommand Desserts_Command = new SqlCommand(query_Desserts, con);
                SqlDataReader reader_Desserts = Desserts_Command.ExecuteReader();

                while (reader_Desserts.Read())
                {

                    if (reader_Desserts[0].ToString() != null && reader_Desserts[1].ToString() != null && reader_Desserts[2].ToString() != null)
                    {
                        one.Meal_name = reader_Desserts[0].ToString();
                        one.Ingredient = reader_Desserts[1].ToString();
                        one.price = Convert.ToDouble(reader_Desserts[2]);
                        one.Desserts_Meal_names.Add(one.Meal_name);
                        one.prices_Desserts.Add(one.price);
                        one.Desserts_Meal_ingredients.Add(one.Ingredient);
                        one.ids_Desserts.Add(reader_Desserts[3].ToString());
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


            con.Open();
            string query_others = "select Meal_Name, Ingredients, price , meal_id from Meals where category_id not in (3, 4, 5, 6)";

            try
            {

                SqlCommand Others_Command = new SqlCommand(query_others, con);
                SqlDataReader reader_Others= Others_Command.ExecuteReader();

                while (reader_Others.Read())
                {

                    if (reader_Others[0].ToString() != null && reader_Others[1].ToString() != null && reader_Others[2].ToString() != null)
                    {
                        one.Meal_name = reader_Others[0].ToString();
                        one.Ingredient = reader_Others[1].ToString();
                        one.price = Convert.ToDouble(reader_Others[2]);
                        one.Others_Meal_names.Add(one.Meal_name);
                        one.prices_Others.Add(one.price);
                        one.Others_Meal_ingredients.Add(one.Ingredient);
                        one.ids_Others.Add(reader_Others[3].ToString());
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


        public async Task<IActionResult> OnGetImagesAsync(string name_of_section)
        {
            //string connection = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            string connection = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";



            using (SqlConnection con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                string query4 = "select Meal_Image from Meals where meal_id = @Id";
                using (SqlCommand cmd_4 = new SqlCommand(query4, con))
                {
                    cmd_4.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
                    if (name_of_section == "Breakfast")
                    {
                        foreach (string id in one.ids_Breakfast)
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
                                        one.Images_Breakfast.Add(ms.ToArray());
                                        //Console.WriteLine(Images_Breakfast.Count());
                                        //Cooker_image = ms.ToArray();
                                    }
                                }
                            }
                        }
                    }
                    else if (name_of_section == "Main")
                    {
                       
                            foreach (string id in one.ids_Main_Courses)
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
                                            one.Images_Main.Add(ms.ToArray());
                                            //Console.WriteLine(Images_Main.Count());
                                            //Cooker_image = ms.ToArray();
                                        }
                                    }
                                }
                            }
                    }
                    else if (name_of_section == "Dessert")
                    {

                        foreach (string id in one.ids_Desserts)
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
                                        one.Images_Desserts.Add(ms.ToArray());
                                        //Console.WriteLine(Images_Desserts.Count());
                                        //Cooker_image = ms.ToArray();
                                    }
                                }
                            }
                        }
                    }
                    else if (name_of_section == "Appetizers")
                    {

                        foreach (string id in one.ids_Appetizers)
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
                                        one.Images_Appetizers.Add(ms.ToArray());
                                        //Console.WriteLine(Images_Appetizers.Count());
                                        //Cooker_image = ms.ToArray();
                                    }
                                }
                            }
                        }
                    }
                    else if (name_of_section == "Others")
                    {

                        foreach (string id in one.ids_Others)
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
                                        one.Images_Others.Add(ms.ToArray());
                                        //Console.WriteLine(Images_Others.Count());
                                        //Cooker_image = ms.ToArray();
                                    }
                                }
                            }
                        }
                    }


                }
            }
            return new ContentResult { Content = string.Empty, ContentType = "text/html" };
        }
       
    }

}
