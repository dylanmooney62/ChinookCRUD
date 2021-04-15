using System.Collections.Generic;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Tracks
{
    public class Index : PageModel
    {

        public IEnumerable<Track> Tracks { get; set; }
        [TempData] public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }


        public void OnGet()
        {
        }
    }
}