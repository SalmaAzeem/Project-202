using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    [BindProperties]
    public class CookersModel : PageModel
    {
        //public Person user = new Person();
        public string name { get; set; }
        public List<Person> cookers { get; set; } = new List<Person>();
        public List<string> ids { get; set; } = new List<string>();
        public List<string> names { get; set; } = new List<string>();
        public void OnGet()
        {
            string connection = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
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
                                    Person cooker = new Person();
                                    cooker.Id = Convert.ToInt32(id);
                                    cooker.UserName = reader_2["UserName"].ToString();
                                    cooker.Email = reader_2["Email"].ToString();
                                    cooker.Phone_Number = Convert.ToInt32(reader_2["Phone_Number"]);
                                    cookers.Add(cooker);
                                }
                            }
                        }
                    }
                    string query3 = "select Description_Cooker from Cooker where Cooker_id = @Id";
                    using (SqlCommand cmd_3 = new SqlCommand(query3, conn))
                    {
                        cmd_3.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
                        foreach (Person Cooker in cookers)
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
    }
}