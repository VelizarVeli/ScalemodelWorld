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
        public async Task<IActionResult> Started()
        {
            var startededModels = await this.scalemodelsService.StartedAll(this.currentUser.GetUserId(User));

            return View("Started/Started", startededModels);
        }

        [Authorize]
        public async Task<IActionResult> StartNewBuild(int id)
        {
            await this.scalemodelsService.StartNewBuildAsync(id, this.currentUser.GetUserId(User));

            return RedirectToAction("Started");
        }

       [Authorize]
        public async Task<IActionResult> DeleteDetails(int id)
       {
           var deleteDetails = await this.scalemodelsService.GetAvailableScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));

            return View("Available/DeleteDetails", deleteDetails);
        }

        [Authorize]
        public async Task<IActionResult> AvailableDelete(int id)
        {
            await this.scalemodelsService.AvailableDeleteAsync(id, this.currentUser.GetUserId(User));
            return RedirectToAction("Available");
        }

        [Authorize]
        public async Task<IActionResult> EditDetails(int id)
        {
            var editDetails = await this.scalemodelsService.GetAvailableScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));

            return View("Available/EditDetails", editDetails);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AvailableEdit(int id, AvailableScalemodelBindingModel model)
        {
            await this.scalemodelsService.AvailableEditAsync(model, id, this.currentUser.GetUserId(User));
            return RedirectToAction("Available");
        }

        [Authorize]
        public async Task<IActionResult> StartedDetails(int id)
        {
            var startedDetails =
                await this.scalemodelsService.GetStartedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));
            if (startedDetails == null)
            {
                return this.RedirectToAction(ActionConstants.Started);
            }

            return View("Started/StartedDetails", startedDetails);
        }

        [Authorize]
        public async Task<IActionResult> Completed()
        {
            var completedModels = await this.scalemodelsService.CompletedAll(this.currentUser.GetUserId(User));

            return View("Completed/Completed", completedModels);
        }

        [Authorize]
        public async Task<IActionResult> FinishBuild(int id)
        {
            await this.scalemodelsService.FinishBuildAsync(id, this.currentUser.GetUserId(User));

            return RedirectToAction("Completed");
        }

        [Authorize]
        public async Task<IActionResult> DeleteStartedDetails(int id)
        {
            var deleteStartedDetails = await this.scalemodelsService.GetStartedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));

            return View("Started/DeleteDetails", deleteStartedDetails);
        }

        [Authorize]
        public async Task<IActionResult> StartedDelete(int id)
        {
            await this.scalemodelsService.StartedDeleteAsync(id, this.currentUser.GetUserId(User));
            return RedirectToAction("Started");
        }

        [Authorize]
        public async Task<IActionResult> EditStartedDetails(int id)
        {
            var editDetails = await this.scalemodelsService.GetStartedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));

            return View("Started/EditDetails", editDetails);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> StartedEdit(int id, StartedScalemodelBindingModel model)
        {
            await this.scalemodelsService.StartedEditAsync(model, id, this.currentUser.GetUserId(User));
            return RedirectToAction("Started");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddWishModel(WishlistScalemodelBindingModel model)
        {
            await this.scalemodelsService.AddWishAsync(model, this.currentUser.GetUserId(User));
            return RedirectToAction("Wishlist");
        }

        [Authorize]
        public async Task<IActionResult> CompletedDetails(int id)
        {
            var completedDetails =
                await this.scalemodelsService.GetCompletedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));
            if (completedDetails == null)
            {
                return this.RedirectToAction(ActionConstants.Completed);
            }

            return View("Completed/CompletedDetails", completedDetails);
        }

        [Authorize]
        public async Task<IActionResult> Wishlist()
        {
            var wishlistModels = await this.scalemodelsService.WishlistAll(this.currentUser.GetUserId(User));
            return View("Wishlist/Wishlist", wishlistModels);
        }

        [Authorize]
        public async Task<IActionResult> DeleteCompletedDetails(int id)
        {
            var deleteCompletedDetails = await this.scalemodelsService.GetCompletedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));

            return View("Completed/DeleteDetails", deleteCompletedDetails);
        }

        [Authorize]
        public async Task<IActionResult> CompletedDelete(int id)
        {
            await this.scalemodelsService.CompletedDeleteAsync(id, this.currentUser.GetUserId(User));
            return RedirectToAction("Completed");
        }

        [Authorize]
        public async Task<IActionResult> EditCompletedDetails(int id)
        {
            var editDetails = await this.scalemodelsService.GetCompletedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));

            return View("Completed/EditDetails", editDetails);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CompletedEdit(int id, CompletedScalemodelBindingModel model)
        {
            await this.scalemodelsService.CompletedEditAsync(model, id, this.currentUser.GetUserId(User));
            return RedirectToAction("Completed");
        }

        [Authorize]
        public IActionResult AddWishModel()
        {
            return View("Wishlist/AddWishModel");
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
