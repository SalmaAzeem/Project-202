using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_DB.Pages
{
    [BindProperties(SupportsGet =true)]
    public class Rating_SuccessModel : PageModel
    {
        public int rating { get; set; }
        public void OnGet()
        {
        }
    }
}
