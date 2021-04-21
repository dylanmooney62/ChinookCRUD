using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinook.Pages.Tracks
{
    public class Delete : PageModel
    {
        private readonly ITrackData _trackData;

        public Delete(ITrackData trackData)
        {
            _trackData = trackData;
        }

        public IActionResult OnPost(int id, int albumId)
        {
            Track track = _trackData.Delete(id);

            if (track == null)
            {
                return RedirectToPage("/NotFound");
            }

            _trackData.Commit();

            TempData["Message"] = $"Track \"{track.Name}\" has been deleted";
            
            return albumId > 0 ? RedirectToPage("/Albums/Detail", new {id = albumId}) : RedirectToPage("./Index");
        }
    }
}