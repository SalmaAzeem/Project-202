using Microsoft.AspNetCore.Mvc;

namespace Project_DB.Models
{
    [BindProperties(SupportsGet = true)]
    public class Cooker
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public byte[] Image_Cooker { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }
        public string city { get; set; }
    }
}
