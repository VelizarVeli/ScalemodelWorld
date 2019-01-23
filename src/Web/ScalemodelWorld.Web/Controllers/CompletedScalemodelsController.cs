using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scalemodel.Data.Models;
using ScalemodelWorld.Common.Constants;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.Scalemodels.Contracts;
using X.PagedList;

namespace ScalemodelWorld.Web.Controllers
{
    public class CompletedScalemodelsController : Controller
    {
        private readonly ScalemodelWorldContext db;
        private readonly ICompletedScalemodelsService completedScalemodelsService;
        private readonly UserManager<ScalemodelWorldUser> currentUser;

        public CompletedScalemodelsController(ScalemodelWorldContext db,
            ICompletedScalemodelsService completedScalemodelsService,
            UserManager<ScalemodelWorldUser> current)
        {
            this.db = db;
            this.completedScalemodelsService = completedScalemodelsService;
            this.currentUser = current;
        }

        [Authorize]
        public async Task<IActionResult> AllCompleted(int? page)
        {
            var completedModels = await this.completedScalemodelsService.AllCompleted(this.currentUser.GetUserId(User));
            var pageNumber = page ?? 1;
            var onePageOfProducts = completedModels.ToPagedList(pageNumber, 10);
            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View("AllCompleted");
        }
        
        [Authorize]
        public async Task<IActionResult> CompletedDetails(int id)
        {
            var completedDetails =
                await this.completedScalemodelsService.GetCompletedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));

            if (completedDetails == null)
            {
                return this.RedirectToAction(ActionConstants.Completed);
            }

            return View("CompletedDetails", completedDetails);
        }

        [Authorize]
        public async Task<IActionResult> DeleteCompletedDetails(int id)
        {
            var deleteCompletedDetails = await this.completedScalemodelsService.GetCompletedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));

            return View("DeleteDetails", deleteCompletedDetails);
        }

        [Authorize]
        public async Task<IActionResult> CompletedDelete(int id)
        {
            await this.completedScalemodelsService.CompletedDeleteAsync(id, this.currentUser.GetUserId(User));
            return RedirectToAction("AllCompleted");
        }

        [Authorize]
        public async Task<IActionResult> EditCompletedDetails(int id)
        {
            var editDetails = await this.completedScalemodelsService.GetCompletedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));

            return View("EditDetails", editDetails);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CompletedModelEdit(int id, CompletedScalemodelBindingModel model)
        {
            await this.completedScalemodelsService.CompletedEditAsync(model, id, this.currentUser.GetUserId(User));
            return RedirectToAction("AllCompleted");
        }
    }
}
