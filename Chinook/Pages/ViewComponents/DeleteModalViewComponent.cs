using Entities;
using Lib;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Pages.ViewComponents
{
    public class DeleteModalViewComponent : ViewComponent
    {
        public DeleteModalViewComponent()
        {
        }

        public IViewComponentResult Invoke(string title, string entity, int id)
        {
            return View(new DeleteModal
            {
                Title = title,
                Entity = entity,
                Id = id
            });
        }
    }
}