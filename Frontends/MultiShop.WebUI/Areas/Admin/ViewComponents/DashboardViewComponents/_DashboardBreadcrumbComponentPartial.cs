using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.DashboardViewComponents
{
    public class _DashboardBreadcrumbComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
