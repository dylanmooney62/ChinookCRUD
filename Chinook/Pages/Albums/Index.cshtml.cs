using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Chinook.Pages.Albums
{
    public class Index : PageModel
    {
        private readonly IAlbumData _albumData;
        public IEnumerable<Entities.Albums> Albums { get; private set; }
        [BindProperty(SupportsGet = true)] public string Search { get; set; }
        [TempData] public string Message { get; set; }

        public Index(IAlbumData albumData)
        {
            _albumData = albumData;
        }

        public void OnGet()
        {
            Albums = _albumData.Search(Search);
        }
    }
}