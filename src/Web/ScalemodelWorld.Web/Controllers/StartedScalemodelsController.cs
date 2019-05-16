using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Scalemodel.Data.Models;
using Scalemodel.Data.Models.Enums;
using ScalemodelWorld.Common.Constants;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Services.Scalemodels.Contracts;
using X.PagedList;

namespace ScalemodelWorld.Web.Controllers
{
    public class StartedScalemodelsController : Controller
    {
        private readonly IStartedScalemodelsService _startedScalemodelsService;
        private readonly UserManager<ScalemodelWorldUser> _currentUser;

        public StartedScalemodelsController(IStartedScalemodelsService startedScalemodelsService,
            UserManager<ScalemodelWorldUser> current)
        {
            _startedScalemodelsService = startedScalemodelsService;
            _currentUser = current;
        }

        [Authorize]
        public async Task<IActionResult> AllStarted(int? page)
        {
            var startededModels = await _startedScalemodelsService.AllStarted(_currentUser.GetUserId(User));
            var pageNumber = page ?? 1;
            var onePageOfProducts = startededModels.ToPagedList(pageNumber, 10);
            ViewBag.OnePageOfProducts = onePageOfProducts;

            return View("AllStarted");
        }


        [Authorize]
        public async Task<IActionResult> StartedDetails(int id)
        {
            var startedDetails =
                await _startedScalemodelsService.GetStartedScalemodelDetailsAsync(id, _currentUser.GetUserId(User));
            if (startedDetails == null)
            {
                return RedirectToAction(ActionConstants.Started);
            }

            return View("StartedDetails", startedDetails);
        }

        [Authorize]
        public async Task<IActionResult> FinishBuild(int id)
        {
            await _startedScalemodelsService.FinishBuildAsync(id, _currentUser.GetUserId(User));

            return RedirectToAction("AllCompleted", "CompletedScalemodels");
        }

        [Authorize]
        public async Task<IActionResult> DeleteStartedDetails(int id)
        {
            var deleteStartedDetails = await _startedScalemodelsService.GetStartedScalemodelDetailsAsync(id, _currentUser.GetUserId(User));

            return View("DeleteDetails", deleteStartedDetails);
        }

       [Authorize]
       public async Task<IActionResult> StartedDelete(int id)
       {
           await _startedScalemodelsService.StartedDeleteAsync(id, _currentUser.GetUserId(User));
           return RedirectToAction("AllStarted");
       }

        [Authorize]
        public async Task<IActionResult> EditStartedDetails(int id, string returnUrl = null)
        {
            var editDetails = await _startedScalemodelsService.GetStartedScalemodelDetailsAsync(id, _currentUser.GetUserId(User));

            var deptList = new List<SelectListItem>();
            deptList.Add(new SelectListItem
            {
                Text = "Select",
                Value = ""
            });
            foreach (Category eVal in Enum.GetValues(typeof(Category)))
            {
                deptList.Add(new SelectListItem { Text = Enum.GetName(typeof(Category), eVal), Value = eVal.ToString() });
            }

            ViewBag.Category = deptList;

            ViewData["ReturnUrl"] = returnUrl;

            return View("EditDetails", editDetails);
        }

       [Authorize]
       [HttpPost]
       public async Task<IActionResult> StartedEdit(int id, StartedScalemodelBindingModel model)
       {
           await _startedScalemodelsService.StartedEditAsync(model, id, _currentUser.GetUserId(User));
           return RedirectToAction("AllStarted");
       }
    }
}
