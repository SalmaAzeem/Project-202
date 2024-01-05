using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_DB.Pages
{
    public class AcceptedModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost() { 
            return RedirectToPage("/DeliveryProfile");
        }
    }
}
