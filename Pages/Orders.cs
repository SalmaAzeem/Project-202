namespace Project_DB.Pages
{
    public class Orders
    {
        public int order_id { get; set; }
        public string destination { get; set; }
        public string payment_type { get; set; }
        public string order_status { get; set; }
        public int customer_id { get; set; }
    }
}
