namespace Project_DB.Pages
{
    public class Meal
    {
        public int Main_Count { get; set; }
        public string Meal_name { get; set; }
        public double price { get; set; }
        public string Ingredient { get; set; }
     
        public List<string> ids_Main_Courses { get; set; } = new List<string>();
        public List<string> ids_Breakfast { get; set; } = new List<string>();
        public List<string> ids_Desserts { get; set; } = new List<string>();
        public List<string> ids_Appetizers { get; set; } = new List<string>();
        public List<string> ids_Others { get; set; } = new List<string>();

        public List<string> Main_Courses_Meal_names = new List<string>();

        public List<string> Breakfast_Meal_names = new List<string>();

        public List<string> Desserts_Meal_names = new List<string>();

        public List<string> Appetizers_Meal_names = new List<string>();

        public List<string> Others_Meal_names = new List<string>();

        public List<string> Main_Courses_Meal_ingredients = new List<string>();

        public List<string> Breakfast_Meal_ingredients = new List<string>();

        public List<string> Desserts_Meal_ingredients = new List<string>();

        public List<string> Appetizers_Meal_ingredients = new List<string>();

        public List<string> Others_Meal_ingredients = new List<string>();

        public List<double> prices_Breakfast = new List<double>();

        public List<double> prices_Desserts = new List<double>();

        public List<double> prices_Main_Courses = new List<double>();

        public List<double> prices_Appetizers = new List<double>();

        public List<double> prices_Others = new List<double>();
        public List<byte[]> Images_Main { get; set; } = new List<byte[]>();
        public List<byte[]> Images_Breakfast { get; set; } = new List<byte[]>();
        public List<byte[]> Images_Desserts { get; set; } = new List<byte[]>();
        public List<byte[]> Images_Appetizers { get; set; } = new List<byte[]>();
        public List<byte[]> Images_Others { get; set; } = new List<byte[]>();
    }
}
