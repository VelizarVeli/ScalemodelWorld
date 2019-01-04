using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scalemodel.Data.Models;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.Scalemodels.Contracts;
using ScalemodelWorld.Web.ViewModels.Scalemodels;

namespace ScalemodelWorld.Web.Controllers
{
    public class ScalemodelsController : Controller
    {
        private readonly ScalemodelWorldContext db;
        //private readonly SeedDatabase seedDatabase;
        private readonly IScalemodelsService scalemodelsService;
        private readonly UserManager<ScalemodelWorldUser> currentUser;

        public ScalemodelsController(ScalemodelWorldContext db/*, SeedDatabase seedDatabase*/,
            IScalemodelsService scalemodelsService,
            UserManager<ScalemodelWorldUser> current)
        {
            this.db = db;
            //this.seedDatabase = seedDatabase;
            this.scalemodelsService = scalemodelsService;
            this.currentUser = current;
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
                DateOfPurchase = a.DateOfPurchase.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                LinkToScalemates = a.LinkToScalemates
            }).OrderBy(n => n.Number).ToList();

            return View("Available/Available", available);
        }

        [Authorize]
        public IActionResult AddModel()
        {
            return View("Available/AddModel");
        }

       //[Authorize]
       //[HttpPost]
       //public IActionResult AddScalemodel(AddBindingModel model)
       //{
       //    var manifacturer = db.Manifacturers.FirstOrDefault(m => m.Name == model.Manifacturer);
       //    if (manifacturer == null)
       //    {
       //        manifacturer = new Manifacturer
       //        {
       //            Name = model.Manifacturer
       //        };

       //        this.db.Manifacturers.Add(manifacturer);
       //        this.db.SaveChanges();
       //    }

       //    var newModel = new AvailableScalemodel
       //    {
       //        BoxPicture = model.BoxPicture,
       //        Number = model.Number,
       //        Name = model.Name,
       //        Scale = model.Scale,
       //        Manifacturer = manifacturer,
       //        FactoryNumber = model.FactoryNumber,
       //        CombinesWith = model.CombinesWith,
       //        InfoHowTo = model.InfoHowTo,
       //        Price = model.Price,
       //        DateOfPurchase = model.DateOfPurchase,
       //        Place = model.Place,
       //        BestCompanyOffer = model.BestCompanyOffer,
       //        Comments = model.Comments,
       //        LinkToScalemates = model.LinkToScalemates
       //    };

       //    this.db.AvailableScalemodels.Add(newModel);
       //    this.db.SaveChanges();

       //    return RedirectToAction("Available");
       //}

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddScalemodel(AddPurchasedScalemodelBindingModel model)
        {
            await this.scalemodelsService.AddScalemodelAsync(model, this.currentUser.GetUserId(User));

            return RedirectToAction("Available");
        }

        [Authorize]
        public IActionResult StartModelBuild(int id)
        {
            return View("Available/Available");
        }

        [Authorize]
        public IActionResult Started()
        {
            //var started = db.StartedScalemodels.Where(o => o.Owner.UserName == this.User.Identity.Name)
            //    .Select(a => new );

            return View();
        }

        [Authorize]
        public async Task<IActionResult> AvailableDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availableDetails = await db.AvailableScalemodels.FindAsync(id);
            /*Select(a => new ScalemodelBindingModel()*/
            //{
            //    Id = a.Id,
            //    BoxPicture = a.BoxPicture,
            //    Number = a.Number,
            //    Name = a.Name,
            //    Scale = a.Scale,
            //    Manifacturer = a.Manifacturer.Name,
            //    FactoryNumber = a.FactoryNumber,
            //    CombinesWith = a.CombinesWith,
            //    InfoHowTo = a.InfoHowTo,
            //    Price = a.Price,
            //    DateOfPurchase = a.DateOfPurchase.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
            //    Place = a.Place,
            //    BestCompanyOffer = a.BestCompanyOffer,
            //    Comments = a.Comments
            //}).FirstOrDefault(n => n.Id == id);

            if (availableDetails == null)
            {
                return NotFound();
            }

            return View("Available/AvailableDetails", availableDetails);
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
            return View("Available/CompletedAll");
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
