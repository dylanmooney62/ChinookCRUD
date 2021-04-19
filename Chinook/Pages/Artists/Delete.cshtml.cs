using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Artists
{
    public class Delete : PageModel
    {
        public IActionResult OnPost()
        {

            TempData["Message"] = "Delete modal accessed";

            return RedirectToPage("./Index");

        }
    }
}