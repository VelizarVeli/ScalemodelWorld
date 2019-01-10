using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ScalemodelWorld.Web.Controllers
{
    public class ModelShowsController : Controller
    {
        public IActionResult Club()
        {
            return View();
        }

        public IActionResult Yours()
        {
            return View();
        }

        public IActionResult Future()
        {
            return View();
        }

        [Authorize]
        public IActionResult AvailableModelshows()
        {
            ViewData["Message"] = "Current available scalemodel exhibitions.";

            return View("Future");
        }
    }
}