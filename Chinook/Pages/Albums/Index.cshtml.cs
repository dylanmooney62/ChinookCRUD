using System.Collections;
using System.Collections.Generic;
using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Albums
{
    public class Index : PageModel
    {
        private readonly IAlbumData _albumData;
        public IEnumerable<Album> Albums { get; private set; }
        
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }
        
        
        public Index(IAlbumData albumData)
        {
            _albumData = albumData;
        }

        public void OnGet()
        {
            Albums = _albumData.GetAlbums(Search);
        }
    }
}