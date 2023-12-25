using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Project_DB.Pages
{
    [BindProperties]
    public class Cooker_interfaceModel : PageModel
    {
		public string CookerName { get; set; }
		public string CookerEmail { get; set; }
		public int CookerPhone { get; set; }
		public void OnGet(string name, string email, string number)
		{
			CookerName = name;
			CookerEmail = email;
			CookerPhone = Int32.Parse(number);
		}
	}
}
