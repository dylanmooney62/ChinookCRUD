using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Artists
{
    public class New : PageModel
    {
        private readonly IArtistData _artistData;

        [BindProperty] public Artist Artist { get; set; }

        public New(IArtistData artistData)
        {
            _artistData = artistData;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            
            _artistData.Add(Artist);

            _artistData.Commit();

            TempData["Message"] = $"Artist \"{Artist.Name}\" created";
            
            return RedirectToPage("./Index");
        }
    }
}