using System.Collections.Generic;
using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Tracks
{
    public class Edit : PageModel
    {

        private readonly ChinookContext _db;
        private readonly ITrackData _trackData;
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<MediaType> MediaTypes { get; set; }
        
        [BindProperty] public Track Track { get; set; }
        
        public Edit(ChinookContext db,ITrackData trackData)
        {
            _trackData = trackData;
            _db = db;
        }

        public IActionResult OnGet(int id)
        {

            Track = _trackData.GetById(id);

            if (Track == null)
            {
                return RedirectToPage("./NotFound");
            }
            
            Albums = _db.Albums;
            Genres = _db.Genres;
            MediaTypes = _db.MediaTypes;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Albums = _db.Albums;
                Genres = _db.Genres;
                MediaTypes = _db.MediaTypes;
                return Page();
            }

            _trackData.Update(Track);

            _trackData.Commit();

            TempData["Message"] = $"Track: \"{Track.Name}\" has been updated";

            return RedirectToPage("/Albums/Detail", new {id = Track.AlbumId});
        }
    }
}