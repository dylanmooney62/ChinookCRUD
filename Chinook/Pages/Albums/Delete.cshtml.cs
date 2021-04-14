using Context;
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

        public void OnGet(int albumId)
        {
            // TempData["Message"] = "You tried to delete an album";
            //
            // return RedirectToPage("./Detail", new {albumId});
        }

        public IActionResult OnPost(int id)
        {
            Entities.Album album = _albumData.GetById(id);

            if (album == null) return RedirectToPage("/NotFound");

            Entities.Album deletedAlbum = _albumData.Delete(album.AlbumId);

            _albumData.Commit();

            if (deletedAlbum == null) return RedirectToPage("/NotFound");

            TempData["Message"] = $"{album.Title} has been deleted";

            return RedirectToPage("./Index");
        }
    }
}