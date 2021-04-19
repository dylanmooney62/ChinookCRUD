using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Tracks
{
    public class Delete : PageModel
    {
        public IActionResult OnPost()
        {

            TempData["Message"] = "Delete Modal accessed";
            
            return RedirectToPage("./Index");
        }
    }
}