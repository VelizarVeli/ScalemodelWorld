using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scalemodel.Data.Models;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services;
using ScalemodelWorld.Web.ViewModels.Scalemodels;

namespace ScalemodelWorld.Web.Controllers
{
    public class ScalemodelsController : Controller
    {
        private readonly ScalemodelWorldContext db;

        //private readonly SeedDatabase seedDatabase;

        public ScalemodelsController(ScalemodelWorldContext db/*, SeedDatabase seedDatabase*/)
        {
            this.db = db;
            //this.seedDatabase = seedDatabase;
        }
        
        [Authorize]
        public IActionResult StartModelBuild(int id)
        {
            return View("Available");
        }

        [Authorize]
        public IActionResult Started()
        {
            //var started = db.StartedScalemodels.Where(o => o.Owner.UserName == this.User.Identity.Name)
            //    .Select(a => new );

            return View();
        }

        [Authorize]
        public IActionResult Available()
        {
            var available = db.AvailableScalemodels.Select(a => new AvailableViewModel
            {
                Number = a.Number,
                Name = a.Name,
                Scale = a.Scale,
                Manifacturer = a.Manifacturer.Name,
                FactoryNumber = a.FactoryNumber,
                CombinesWith = a.CombinesWith,
                InfoHowTo = a.InfoHowTo,
                Price = a.Price
            }).ToList();

            return View(available);
        }

        [Authorize]
        public IActionResult AddWishList()
        {
            //seedDatabase.

            return View("Wishlist");
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
