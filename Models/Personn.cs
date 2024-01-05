//using IronPdf.Razor.Pages;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Project_DB.Models;

//namespace Project_DB.Pages
//{
//    public class PersonsModel : PageModel
//    {
//        [BindProperty(SupportsGet = true)]
//        public List<Personn> persons { get; set; }

//        public void OnGet()
//        {
//            persons = new List<Personn>
//            {
//            new Personn { Name = "Alice", Title = "Mrs.", Description = "Software Engineer" },
//            new Personn { Name = "Bob", Title = "Mr.", Description = "Software Engineer" },
//            new Personn { Name = "Charlie", Title = "Mr.", Description = "Software Engineer" }
//            };

//            ViewData["personList"] = persons;
//        }
//        public IActionResult OnPostAsync()
//        {
//            persons = new List<Personn>
//            {
//            new Personn { Name = "Alice", Title = "Mrs.", Description = "Software Engineer" },
//            new Personn { Name = "Bob", Title = "Mr.", Description = "Software Engineer" },
//            new Personn { Name = "Charlie", Title = "Mr.", Description = "Software Engineer" }
//            };

//            ViewData["personList"] = persons;

//            ChromePdfRenderer renderer = new ChromePdfRenderer();

//            // Render Razor Page to PDF document
//            PdfDocument pdf = renderer.RenderRazorToPdf(this);

//            Response.Headers.Add("Content-Disposition", "inline");

//            return File(pdf.BinaryData, "application/pdf", "razorPageToPdf.pdf");

//            // View output PDF on broswer
//            return File(pdf.BinaryData, "application/pdf");
//        }
//    }
//}
