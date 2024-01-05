using Microsoft.AspNetCore.Mvc;

namespace Project_DB.Pages
{
    [BindProperties (SupportsGet = true)]
    public class order
    {

        public int order_Id { get; set; }
        public int cooker_Id { get; set;}

        public int meal_Id { get; set; }

        public string meal_Name { get; set; }
        public string destination { get; set; }
        public string payment_type { get; set; }
        public string order_status { get; set; }
        public int customer_id { get; set; }
    }
}
