using System.Collections.Generic;
using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace Chinook.Pages.Albums
{
    public class Index : PageModel
    {
        private readonly IAlbumData _albumData;
        public IEnumerable<Album> Albums { get; private set; }
        [BindProperty(SupportsGet = true)] public string Search { get; set; }
        [TempData] public string Message { get; set; }

        public Index(IAlbumData albumData)
        {
            _albumData = albumData;
        }

        public void OnGet(int? p)
        {
            Albums = _albumData.Search(Search);

            int page = p ?? 1;

            Albums = Albums.ToPagedList(page, 12);
        }
    }
}