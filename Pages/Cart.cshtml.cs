using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_DB.Pages
{
    public class CartModel : PageModel
    {
        public string id_cart { get; set; }
        public string my_identifier { get; set; }
        public List<string> identifiers { get; set; } = new List<string>();
        public List<string> ids_Cart { get; set; } = new List<string>();
        public void OnGet(string id, string identifier)
        {
            id_cart = id;
            ids_Cart.Add(id_cart);
            my_identifier = identifier;
            identifiers.Add(my_identifier);

        }
      
    }
}
