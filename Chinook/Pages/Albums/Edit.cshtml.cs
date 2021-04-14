using System.Collections.Generic;
using System.Linq;
using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Albums
{
    public class Edit : PageModel
    {
        private readonly ChinookContext _db;
        private readonly IAlbumData _albumData;

        [BindProperty] public Album Album { get; set; }

        public IEnumerable<Artist> Artists { get; set; }

        public Edit(IAlbumData albumData, ChinookContext db)
        {
            _db = db;
            _albumData = albumData;
        }

        public IActionResult OnGet(int id)
        {
            Album = _albumData.GetById(id);

            Artists = _db.Artists.OrderBy(a => a.Name);

            if (Album == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _albumData.Update(Album);

            _albumData.Commit();

            TempData["Message"] = "Album has been updated";

            return RedirectToPage("./Detail", new {id = Album.AlbumId});
        }
    }
}