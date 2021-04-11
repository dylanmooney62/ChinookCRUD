using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Albums
{
    public class Detail : PageModel
    {
        private readonly IAlbumData _albumData;
        public Entities.Albums Album { get; set; }

        [TempData] public string Message { get; set; }

        public Detail(IAlbumData albumData)
        {
            _albumData = albumData;
        }
        
        public IActionResult OnGet(int albumId)
        {
            Album = _albumData.GetById(albumId);

            if (Album == null) return RedirectToPage("/NotFound");
            
            return Page();
        }
    }
}