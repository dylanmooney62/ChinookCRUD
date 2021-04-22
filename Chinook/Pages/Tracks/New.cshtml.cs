using System;
using System.Collections.Generic;
using Context;
using Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Tracks
{
    public class New : PageModel
    {
        private readonly ITrackData _trackData;
        private readonly ChinookContext _db;

        [BindProperty] public Track Track { get; set; }
        [BindProperty(SupportsGet = true)] public int AlbumId { get; set; }
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<MediaType> MediaTypes { get; set; }


        public New(ITrackData trackData, ChinookContext db)
        {
            _trackData = trackData;
            _db = db;
        }

        public void OnGet()
        {
            PopulateSelects();
        }

        public IActionResult OnPost()
        {
            // this is random as you wouldn't expect a user to specify the time for a track they're uploading
            Track.Milliseconds = new Random().Next(0, 200000);

            if (!ModelState.IsValid)
            {
                PopulateSelects();
                return Page();
            }

            _trackData.Add(Track);

            _trackData.Commit();

            TempData["Message"] = $"Track: \"{Track.Name}\" has been created";

            return AlbumId > 0 ? RedirectToPage("/Albums/Detail", new {id = AlbumId}) : RedirectToPage("./Index");
        }

        private void PopulateSelects()
        {
            Albums = _db.Albums;
            Genres = _db.Genres;
            MediaTypes = _db.MediaTypes;
        }
    }
}