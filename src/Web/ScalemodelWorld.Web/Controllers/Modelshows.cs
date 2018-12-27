using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ScalemodelWorld.Web.Controllers
{
    public class Modelshows : Controller
    {
        [Authorize]
        public IActionResult AvailableModelshows()
        {
            ViewData["Message"] = "Current available scalemodel exhibitions.";

            return View("Modelshows");
        }
    }
}
