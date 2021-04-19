using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Albums
{
    public class Delete : PageModel
    {
        
        public IActionResult OnPost()
        {
            TempData["Message"] = "Delete album modal was accessed";
            
            return RedirectToPage("/Albums/Index");
        }
    }
}