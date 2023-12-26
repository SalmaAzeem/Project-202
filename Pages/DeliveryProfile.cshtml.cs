using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class DeliveryProfileModel : PageModel
    {
        [BindProperty]
        public  int ID2 { get; set; }
        public void OnGet()
        {
        }
    }
}
