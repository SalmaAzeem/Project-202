using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    public class signupModel : PageModel
    {
        public Person personinfo = new Person();
        public void OnGet()
        {
        }

        public void OnPost() { 
            personinfo.name = Request.Form["name"];
            string passString = Request.Form["password"];
            personinfo.email = Request.Form["email"];
        }
    }
}
