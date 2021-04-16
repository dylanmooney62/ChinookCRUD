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
        private readonly IAlbumData _albumData;
        private readonly ChinookContext _db;

        [BindProperty] public Track Track { get; set; }

        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<MediaType> MediaTypes { get; set; }

        [BindProperty] public int AlbumId { get; set; }


        public New(ITrackData trackData, IAlbumData albumData, ChinookContext db)
        {
            _trackData = trackData;
            _albumData = albumData;
            _db = db;
        }

        public void OnGet(int? albumId)
        {
            if (albumId != null) AlbumId = (int) albumId;

            Albums = _albumData.Search(null);
            Genres = _db.Genres;
            MediaTypes = _db.MediaTypes;
        }

        public IActionResult OnPost(int? albumId)
        {
            // this is temp as you wouldn't really expect a user to specify the time for a track they're uploading
            Track.Milliseconds = new Random().Next(0, 200000);

            if (!ModelState.IsValid)
            {
                Albums = _albumData.Search(null);
                Genres = _db.Genres;
                MediaTypes = _db.MediaTypes;

                return Page();
            }

            _trackData.Add(Track);

            _trackData.Commit();

            TempData["Message"] = "Track Added";

            return albumId > 0 ? RedirectToPage("/Albums/Detail", new {id = albumId}) : RedirectToPage("./Index");
        }
    }
}