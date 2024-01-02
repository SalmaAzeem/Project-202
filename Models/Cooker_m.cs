using Microsoft.AspNetCore.Mvc;

namespace Project_DB.Models
{
    [BindProperties(SupportsGet = true)]
    public class Cooker_m
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public byte[] Image_Cooker { get; set; }
        public int Phone_Number { get; set; }
        public string Email { get; set; }

    }
}
