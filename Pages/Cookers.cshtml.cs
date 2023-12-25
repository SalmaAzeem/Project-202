using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    [BindProperties]
    public class CookersModel : PageModel
    {
        //public Person user = new Person();
        public List<Person> cookers {  get; set; } = new List<Person>();
        public List<string> ids { get; set; } = new List<string>();
		public void OnGet()
		{
            string connection = "Data Source=Tamer;Initial Catalog=\"Project 2.0\";Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "select Cooker_id from Cooker";
                    string query2 = "select UserName, Email, Phone_Number from Userr where ID = @Id";
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
                    using (SqlCommand cmd_2 = new SqlCommand(query2, conn))
                    {
                        using (SqlDataReader reader_2 = cmd_2.ExecuteReader())
                        {
                            if (reader_2.Read())
                            {
                                for (int i = 0; i < ids.Count(); i++)
                                {
                                    cmd_2.Parameters["@Id"].Value = ids[i];
                                    Person cooker = new Person();
                                    cooker.UserName = reader_2["UserName"].ToString();
                                    cooker.Email = reader_2["Email"].ToString();
                                    cooker.Phone_Number = (int)reader_2["Phone_Number"];
                                    cookers.Add(cooker);
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
