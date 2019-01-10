using System;
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
    public class StartedScalemodelsController : Controller
    {
        private readonly ScalemodelWorldContext db;
        private readonly IStartedScalemodelsService startedScalemodelsService;
        private readonly UserManager<ScalemodelWorldUser> currentUser;

        public StartedScalemodelsController(ScalemodelWorldContext db,
            IStartedScalemodelsService startedScalemodelsService,
            UserManager<ScalemodelWorldUser> current)
        {
            this.db = db;
            this.startedScalemodelsService = startedScalemodelsService;
            this.currentUser = current;
        }

        [Authorize]
        public async Task<IActionResult> AllStarted()
        {
            var startededModels = await this.startedScalemodelsService.AllStarted(this.currentUser.GetUserId(User));

            return View("AllStarted", startededModels);
        }


        [Authorize]
        public async Task<IActionResult> StartedDetails(int id)
        {
            var startedDetails =
                await this.startedScalemodelsService.GetStartedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));
            if (startedDetails == null)
            {
                return this.RedirectToAction(ActionConstants.Started);
            }

            return View("StartedDetails", startedDetails);
        }

        [Authorize]
        public async Task<IActionResult> FinishBuild(int id)
        {
            await this.startedScalemodelsService.FinishBuildAsync(id, this.currentUser.GetUserId(User));

            return RedirectToAction("StartedDetails");
            //return RedirectToAction("AllCompleted", CompletedScalemodels);
        }

        [Authorize]
        public async Task<IActionResult> DeleteStartedDetails(int id)
        {
            var deleteStartedDetails = await this.startedScalemodelsService.GetStartedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));

            return View("DeleteDetails", deleteStartedDetails);
        }

       [Authorize]
       public async Task<IActionResult> StartedDelete(int id)
       {
           await this.startedScalemodelsService.StartedDeleteAsync(id, this.currentUser.GetUserId(User));
           return RedirectToAction("AllStarted");
       }

        [Authorize]
        public async Task<IActionResult> EditStartedDetails(int id)
        {
            var editDetails = await this.startedScalemodelsService.GetStartedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));

            return View("EditDetails", editDetails);
        }

       [Authorize]
       [HttpPost]
       public async Task<IActionResult> StartedEdit(int id, StartedScalemodelDto model)
       {
           await this.startedScalemodelsService.StartedEditAsync(model, id, this.currentUser.GetUserId(User));
           return RedirectToAction("AllStarted");
       }
    }
}
