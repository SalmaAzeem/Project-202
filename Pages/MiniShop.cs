namespace Project_DB.Pages
{
    public class MiniShop
    {
        public int Minishop_Count { get; set; }
        public string food_cans_name { get; set; }
        public double price { get; set; }
        public List<string> food_cans_names = new List<string>();

        public List<double> prices = new List<double>();
        public List<string> ids_Minishop { get; set; } = new List<string>();
        public List<byte[]> Images_Minishop { get; set; } = new List<byte[]>();
    }
}
