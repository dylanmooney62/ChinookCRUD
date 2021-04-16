using System.Collections.Generic;
using System.Linq;
using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Albums
{
    public class New : PageModel
    {
        private readonly IAlbumData _albumData;
        private readonly ChinookContext _db;

        [BindProperty] public Album Album { get; set; }
        public IEnumerable<Artist> Artists { get; set; }

        public New(IAlbumData albumData, ChinookContext db)
        {
            _albumData = albumData;
            _db = db;
        }
        
        public void OnGet()
        {
            Artists = _db.Artists.OrderBy(a => a.Name);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            
            _albumData.Add(Album);

            _albumData.Commit();
            
            TempData["Message"] = "Album created";

            return RedirectToPage("./Detail", new {id = Album.AlbumId});
        }
    }
}