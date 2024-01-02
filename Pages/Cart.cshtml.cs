using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_DB.Pages
{
    public class CartModel : PageModel
    {
        public string id_minishop { get; set; }
        public List<string> ids_Cart { get; set; } = new List<string>();
        public void OnGet(string id)
        {
            id_minishop = id;
            ids_Cart.Add(id_minishop);
        }
      
    }
}
