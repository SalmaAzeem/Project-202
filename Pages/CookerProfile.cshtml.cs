using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DB.Models;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Project_DB.Pages
{
    public class CookerProfileModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID2 { get; set; }

        [BindProperty(SupportsGet = true)]
        public Cooker cookerinfo { get; set; }

        public List<order> orderlist = new List<order>();

        [BindProperty]
        public bool there { get; set; }






        public void OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null)
            {
                ID2 = userId.Value;

            }
            try
            {
                //string connectionString = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";
                string connectionString = "Data Source =Tamer; Initial Catalog = Project 2.0; Integrated Security = True";
                //ID2 = userId;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string q2 = "SELECT * FROM Userr " +
                                "INNER JOIN Cooker ON Userr.ID = Cooker.cooker_id " +
                                "WHERE Userr.ID = @ID";
                    using (SqlCommand cmd = new SqlCommand(q2, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID2);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            cookerinfo.Id = Convert.ToInt32(reader["ID"]);
                            cookerinfo.UserName = reader["UserName"].ToString();
                            cookerinfo.Email = reader["Email"].ToString();
                            cookerinfo.Phone_Number = reader["Phone_Number"].ToString();
                            cookerinfo.User_Password = reader["User_Password"].ToString();
                            cookerinfo.city = reader["city"].ToString(); 
                            cookerinfo.street = reader["street"].ToString();
                            cookerinfo.Apartment_Number = reader["Apartment_Number"].ToString();

                        }
                    }





                    string selection = "SELECT o.order_id, c.meal_id, m.Meal_Name " +
                        "FROM Orders AS o, Participate_In_Meals AS p, Cooks_Meal AS c, Meals AS m " +
                        "WHERE o.order_id = p.order_id AND c.meal_id = p.meal_id AND c.meal_id = m.meal_id " +
                        "AND o.order_status = 'Not Delivered' AND c.Cooker_id = @ID and o.cooking_status = 'Waiting'";

                    string count  = "select count(*)"+
                    " from Orders as o,Participate_In_Meals as p ,Cooks_Meal as c"+
                    " where o.order_id = p.order_id and c.meal_id = p.meal_id and c.Cooker_id = @ID and  o.order_status = 'Not Delivered' and o.cooking_status = 'Waiting'";

                
                    using (SqlCommand cmd = new SqlCommand(count, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID2);
                        int ordercounter = Convert.ToInt32(cmd.ExecuteScalar());
                        if (ordercounter > 0)
                        {
                            there = true;
                        }
                        else there = false;
                    }
                    if (there)
                    {
                        using (SqlCommand com = new SqlCommand(selection, con))
                        {
                            com.Parameters.AddWithValue("@ID", ID2);

                            using (SqlDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    order order = new order();
                                    order.cooker_Id = ID2;
                                    order.order_Id = reader.GetInt32(0);
                                    order.meal_Id = reader.GetInt32(1);
                                    order.meal_Name = reader.GetString(2);

                                    orderlist.Add(order);
                                }
                            }
                        }

                    }
  
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        //public IActionResult OnPost()
        //{
        //    //var userId = HttpContext.Session.GetString("UserId");
        //    ////ID2 = userId.Value;
        //    //try
        //    //    {
        //    //    string connectionString = "Data Source =LAPTOP-8L98OTBR; Initial Catalog = Project 2.0; Integrated Security = True";

        //    //    string selection = "SELECT o.order_id, c.meal_id, m.Meal_Name " +
        //    //                        "FROM Orders AS o, Participate_In_Meals AS p, Cooks_Meal AS c, Meals AS m " +
        //    //                        "WHERE o.order_id = p.order_id AND c.meal_id = p.meal_id AND c.meal_id = m.meal_id " +
        //    //                        "AND o.order_status = 'Not Delivered' AND c.Cooker_id = @ID";
        //    //    using (SqlConnection con = new SqlConnection(connectionString))
        //    //        {
        //    //            con.Open();
        //    //            string q2 = "DELETE FROM Orders WHERE order_id=@ID";
        //    //            using (SqlCommand cmd = new SqlCommand(selection, con))
        //    //            {
        //    //                cmd.Parameters.AddWithValue("@ID", ID2);
        //    //                cmd.ExecuteNonQuery();
        //    //            }
        //    //        }
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        Console.WriteLine(ex.ToString());
        //    //    }
        //    return RedirectToPage("/Shared/Delete");

        //}



    }
}
