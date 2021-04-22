using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Albums
{
    public class Delete : PageModel
    {
        private readonly IAlbumData _albumData;

        public Delete(IAlbumData albumData)
        {
            _albumData = albumData;
        }
        public IActionResult OnPost(int id)
        {
            Album album = _albumData.Delete(id);

            if (album == null) return RedirectToPage("/NotFound");
            
            _albumData.Commit();
            
            TempData["Message"] = $"Album: \"{album.Title}\" has been deleted";
            
            return RedirectToPage("/Albums/Index");
        }
    }
}