using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scalemodel.Data.Models;
using ScalemodelWorld.Common.Constants;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.Scalemodels.Contracts;

namespace ScalemodelWorld.Web.Controllers
{
    public class ScalemodelsController : Controller
    {
        private readonly ScalemodelWorldContext db;
        private readonly IScalemodelsService scalemodelsService;
        private readonly UserManager<ScalemodelWorldUser> currentUser;

        public ScalemodelsController(ScalemodelWorldContext db/*, SeedDatabase seedDatabase*/,
            IScalemodelsService scalemodelsService,
            UserManager<ScalemodelWorldUser> current)
        {
            this.db = db;
            this.scalemodelsService = scalemodelsService;
            this.currentUser = current;
        }

        [Authorize]
        public async Task<IActionResult> Available()
        {
            var purchasedModels = await this.scalemodelsService.AvailableAll(this.currentUser.GetUserId(User));
            return View("Available/Available", purchasedModels);
        }

        [Authorize]
        public IActionResult AddModel()
        {
            return View("Available/AddModel");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddScalemodel(AvailableScalemodelBindingModel model)
        {
            await this.scalemodelsService.AddScalemodelAsync(model, this.currentUser.GetUserId(User));

            return RedirectToAction("Available");
        }

        [Authorize]
        public async Task<IActionResult> AvailableDetails(int id)
        {
            var availableDetails =
                await this.scalemodelsService.GetAvailableScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));
            if (availableDetails == null)
            {
                return this.RedirectToAction(ActionConstants.Available);
            }

            return View("Available/AvailableDetails", availableDetails);
        }

        [Authorize]
        public IActionResult StartModelBuild(int id)
        {
            return View("Available/Available");
        }

        [Authorize]
        public async Task<IActionResult> Started()
        {
            var startededModels = await this.scalemodelsService.AvailableAll(this.currentUser.GetUserId(User));
            return View("Available/Available", startededModels);
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
