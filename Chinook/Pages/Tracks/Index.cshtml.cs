using System.Collections.Generic;
using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace Chinook.Pages.Tracks
{
    public class Index : PageModel
    {
        private readonly ITrackData _trackData;
        public IEnumerable<Track> Tracks { get; set; }
        [BindProperty(SupportsGet = true)] public string Search { get; set; }
        [TempData] public string Message { get; set; }


        public Index(ITrackData trackData)
        {
            _trackData = trackData;
        }


        public void OnGet(int? p)
        {
            Tracks = _trackData.Search(Search);
            
            int page = p ?? 1;

            Tracks = Tracks.ToPagedList(page, 12);
        }
    }
}