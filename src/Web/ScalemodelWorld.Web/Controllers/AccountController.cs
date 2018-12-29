using Microsoft.AspNetCore.Mvc;

namespace ScalemodelWorld.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
