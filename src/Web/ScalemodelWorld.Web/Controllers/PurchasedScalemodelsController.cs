using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scalemodel.Data.Models;
using ScalemodelWorld.Common.Constants;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.Scalemodels.Contracts;
using ScalemodelWorld.Services.SeedData.Dto;

namespace ScalemodelWorld.Web.Controllers
{
    public class PurchasedScalemodelsController : Controller
    {
        private readonly ScalemodelWorldContext db;
        private readonly IPurchasedScalemodelsService purchasedScalemodelsService;
        private readonly UserManager<ScalemodelWorldUser> currentUser;

        public PurchasedScalemodelsController(ScalemodelWorldContext db,
            IPurchasedScalemodelsService purchasedScalemodelsService,
            UserManager<ScalemodelWorldUser> current)
        {
            this.db = db;
            this.purchasedScalemodelsService = purchasedScalemodelsService;
            this.currentUser = current;
        }

        [Authorize]
        public async Task<IActionResult> AllPurchased()
        {
            var purchasedModels = await this.purchasedScalemodelsService.AllPurchased(this.currentUser.GetUserId(User));
            return View("AllPurchased", purchasedModels);
        }

        [Authorize]
        public IActionResult AddModel()
        {
            return View("AddModel");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddScalemodel(PurchasedScalemodelBindingModel model)
        {
            await this.purchasedScalemodelsService.AddPurchasedAsync(model, this.currentUser.GetUserId(User));

            return RedirectToAction("AllPurchased");
        }

       [Authorize]
       public async Task<IActionResult> PurchasedDetails(int id)
       {
           var purchasedDetails =
               await this.purchasedScalemodelsService.GetPurchasedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));
           if (purchasedDetails == null)
           {
               return this.RedirectToAction(ActionConstants.Purchased);
           }

           return View("PurchasedModelDetails", purchasedDetails);
       }

        [Authorize]
        public async Task<IActionResult> StartNewBuild(int id)
        {
            await this.purchasedScalemodelsService.StartNewBuildAsync(id, this.currentUser.GetUserId(User));

            return RedirectToAction("AllStarted","StartedScalemodels");
        }

        [Authorize]
        public async Task<IActionResult> DeleteDetails(int id)
        {
            var deleteDetails = await this.purchasedScalemodelsService.GetPurchasedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));

            return View("DeleteDetails", deleteDetails);
        }

        [Authorize]
        public async Task<IActionResult> PurchasedDelete(int id)
        {
            await this.purchasedScalemodelsService.PurchasedDeleteAsync(id, this.currentUser.GetUserId(User));
            return RedirectToAction("AllPurchased");
        }

        [Authorize]
        public async Task<IActionResult> EditDetails(int id)
        {
            var editDetails = await this.purchasedScalemodelsService.GetPurchasedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));

            return View("EditDetails", editDetails);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PurchasedEdit(int id, PurchasedScalemodelBindingModel model)
        {
            await this.purchasedScalemodelsService.PurchasedEditAsync(model, id, this.currentUser.GetUserId(User));
            return RedirectToAction("AllPurchased");
        }
    }
}