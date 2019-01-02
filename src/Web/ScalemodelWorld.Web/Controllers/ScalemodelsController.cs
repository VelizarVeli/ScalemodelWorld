using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScalemodelWorld.Data;
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
                Id = a.Id,
                BoxPicture = a.BoxPicture,
                Number = a.Number,
                Name = a.Name,
                Price = a.Price.ToString("##.00"),
                DateOfPurchase = a.DateOfPurchase.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
            }).OrderBy(n => n.Number).ToList();

            return View(available);
        }

        [Authorize]
        public IActionResult AvailableDetails(int id)
        {
            AvailableDetailsViewModel availableDetails = db.AvailableScalemodels.Select(a => new AvailableDetailsViewModel()
            {
                Id = a.Id,
                BoxPicture = a.BoxPicture,
                Number = a.Number,
                Name = a.Name,
                Scale = a.Scale,
                Manifacturer = a.Manifacturer.Name,
                FactoryNumber = a.FactoryNumber,
                CombinesWith = a.CombinesWith,
                InfoHowTo = a.InfoHowTo,
                Price = a.Price.ToString("##.00"),
                DateOfPurchase = a.DateOfPurchase.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                Place = a.Place,
                BestCompanyOffer = a.BestCompanyOffer,
                Comments = a.Comments
            }).FirstOrDefault(n => n.Id == id);

           //if (availableDetails == null)
            //{
            //    return this.("Invalid product id.");
            //}

            return View(availableDetails);
        }

        [Authorize]
        public IActionResult AddWishList()
        {
            //seedDatabase.

            return View("Wishlist");
        }

        [Authorize]
        public IActionResult CompletedAll()
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
