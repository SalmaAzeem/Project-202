using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class DeliveryProfileModel : PageModel
    {
        [BindProperty]
        public Person personinfo2 { get; set; }
        public void OnGet()
        {
        }
    }
}
