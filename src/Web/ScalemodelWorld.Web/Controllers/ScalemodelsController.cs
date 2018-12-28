using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ScalemodelWorld.Web.Controllers
{
    public class ScalemodelsController : Controller
    {
        [Authorize]
        public IActionResult Started()
        {
            return View();
        }
        [Authorize]
        public IActionResult Available()
        {
            return View();
        }
        [Authorize]
        public IActionResult Completed()
        {
            return View();
        }
        [Authorize]
        public IActionResult Wishlist()
        {
            return View();
        }

        [Authorize]
        public IActionResult ListOfStarted()
        {
            return View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        public IActionResult Delete()
        {
            return View();
        }

        [Authorize]
        public IActionResult Details()
        {
            return View();
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
