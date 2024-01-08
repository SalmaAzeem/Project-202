using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Project_DB.Models
{
    public class DB
    {
        [BindProperty(SupportsGet =true)]
        public Person person { get; set; }
        public string connectionString { get; set; }
        public DB()
        {
            string connectionString = "Data Source =Tamer; Initial Catalog = Project 2.0; Integrated Security = True";
            //string connectionString = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";

        }
        public void SignUp(Person personinfo)
        {
                //string validation = "select count(*) from Userr where UserName = @UserName and Email = @Email";
                //int counter = Convert.ToInt32(command.ExecuteScalar());

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q = "INSERT INTO Userr" +
                        "(ID, UserName,Email,Phone_Number,User_Password,User_Type) VALUES" +
                        "(@ID, @UserName,@Email,@Phone_Number,@User_Password,@User_Type)";

                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        
                        cmd.Parameters.AddWithValue("@ID", personinfo.Id);
                        cmd.Parameters.AddWithValue("@UserName", personinfo.UserName);
                        cmd.Parameters.AddWithValue("@User_Password", personinfo.User_Password);
                        cmd.Parameters.AddWithValue("@Email", personinfo.Email);
                        cmd.Parameters.AddWithValue("@Phone_Number", personinfo.Phone_Number);

                        cmd.Parameters.AddWithValue("@User_Type", personinfo.User_Type);
                        person.Id = personinfo.Id;
                        person.UserName = personinfo.UserName;
                        person.Phone_Number = personinfo.Phone_Number;

                        person.Email = personinfo.Email;
                        person.User_Type = personinfo.User_Type;
                        person.User_Password = personinfo.User_Password;
                        cmd.ExecuteNonQuery();

                    }

                }


            
        }
    }
}
