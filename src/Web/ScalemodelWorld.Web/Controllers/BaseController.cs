using Microsoft.AspNetCore.Mvc;
using ScalemodelWorld.Data;
using ScalemodelWorld.Web.Models;

namespace ScalemodelWorld.Web.Controllers
{
    public class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new ScalemodelWorldContext();
        }

        protected ScalemodelWorldContext Db { get; }
    }
}
