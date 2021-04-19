using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Artists
{
    public class Edit : PageModel
    {
        private readonly IArtistData _artistData;

        [BindProperty] public Artist Artist { get; set; }

        public Edit(IArtistData artistData)
        {
            _artistData = artistData;
        }


        public IActionResult OnGet(int id)
        {
            Artist = _artistData.GetById(id);

            if (Artist == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _artistData.Update(Artist);

            _artistData.Commit();

            TempData["Message"] = $"Artist {Artist.Name} updated";

            return RedirectToPage("./Index");
        }
    }
}