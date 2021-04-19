using System.Collections.Generic;
using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace Chinook.Pages.Artists
{
    public class Index : PageModel
    {
        private readonly IArtistData _artistData;

        public Index(IArtistData artistData)
        {
            _artistData = artistData;
        }

        public IEnumerable<Artist> Artists { get; private set; }
        
        [BindProperty(SupportsGet = true)] public string Search { get; set; }
        
        [TempData] public string Message { get; set; }


        public void OnGet(int? p)
        {
            Artists = _artistData.Search(Search);
            
            int page = p ?? 1;

            Artists = Artists.ToPagedList(page, 12);
        }
    }
}