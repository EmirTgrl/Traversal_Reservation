using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ReferenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
