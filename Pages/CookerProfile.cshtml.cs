using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_DB.Pages
{
    public class CookerProfileModel : PageModel
    {
        [BindProperty]
        public Person personinfo2 { get; set; }
        public void OnGet()
        {
        }
    }
}
