using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.ViewComponents
{
    public class _SidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
