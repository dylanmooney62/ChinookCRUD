using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Albums
{
    public class Detail : PageModel
    {
        private readonly IAlbumData _albumData;
        public Album Album { get; set; }


        public Detail(IAlbumData albumData)
        {
            _albumData = albumData;
        }


        public IActionResult OnGet(int albumId)
        {
            Album = _albumData.GetAlbumById(albumId);
            
            return Album != null ? Page() : (ActionResult) RedirectToPage("/NotFound");
        }
    }
}