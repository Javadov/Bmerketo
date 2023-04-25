using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BreadcrumbController : Controller
    {
        public IActionResult BreadcrumbTrail()
        {
            var breadcrumbTrail = new List<BreadCrumbModel>();
            return PartialView("_Breadcrumb", breadcrumbTrail);
        }
    }
}
