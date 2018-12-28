using Microsoft.AspNetCore.Mvc;

namespace ScalemodelWorld.Web
{
    public class ScalemodelsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return this.View();
        }
    }
}