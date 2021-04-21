using System.Collections;
using System.Collections.Generic;
using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Artists
{
    public class Delete : PageModel
    {
        private readonly IArtistData _artistData;
        
    

        public Delete(IArtistData artistData)
        {
            _artistData = artistData;
        }


        public IActionResult OnPost(int id)
        {
            Artist artist = _artistData.Delete(id);
            

            if (artist == null)
            {
                return RedirectToPage("/NotFound");
            }

            TempData["Message"] = $"{artist.Name} has been deleted";

            return RedirectToPage("./Index");
        }
    }
}