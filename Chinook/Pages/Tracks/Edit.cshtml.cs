using System.Collections.Generic;
using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Tracks
{
    public class Edit : PageModel
    {
        private readonly ITrackData _trackData;
        private readonly ChinookContext _db;
        [BindProperty] public Track Track { get; set; }
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<MediaType> MediaTypes { get; set; }

        public Edit(ITrackData trackData, ChinookContext db)
        {
            _trackData = trackData;
            _db = db;
        }

        public IActionResult OnGet(int id)
        {
            Track = _trackData.GetById(id);

            if (Track == null) return RedirectToPage("/NotFound");

            PopulateSelects();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                PopulateSelects();
                return Page();
            }

            _trackData.Update(Track);

            _trackData.Commit();

            TempData["Message"] = $"Track: \"{Track.Name}\" has been updated";

            return Track.AlbumId != null
                ? RedirectToPage("/Albums/Detail", new {id = Track.AlbumId})
                : RedirectToPage("./Index");
        }

        private void PopulateSelects()
        {
            Albums = _db.Albums;
            Genres = _db.Genres;
            MediaTypes = _db.MediaTypes;
        }
    }
}