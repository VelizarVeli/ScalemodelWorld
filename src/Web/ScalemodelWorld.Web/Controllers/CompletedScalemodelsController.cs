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
    public class CompletedScalemodelsController : Controller
    {
        private readonly ICompletedScalemodelsService _completedScalemodelsService;
        private readonly UserManager<ScalemodelWorldUser> _currentUser;

        public CompletedScalemodelsController(ICompletedScalemodelsService completedScalemodelsService,
            UserManager<ScalemodelWorldUser> current)
        {
            _completedScalemodelsService = completedScalemodelsService;
            _currentUser = current;
        }

        [Authorize]
        public async Task<IActionResult> AllCompleted(int? page)
        {
            var completedModels = await _completedScalemodelsService.AllCompleted(_currentUser.GetUserId(User));
            var pageNumber = page ?? 1;
            var onePageOfProducts = completedModels.ToPagedList(pageNumber, 10);
            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View("AllCompleted");
        }
        
        [Authorize]
        public async Task<IActionResult> CompletedDetails(int id)
        {
            var completedDetails =
                await _completedScalemodelsService.GetCompletedScalemodelDetailsAsync(id, _currentUser.GetUserId(User));

            if (completedDetails == null)
            {
                return RedirectToAction(ActionConstants.Completed);
            }

            return View("CompletedDetails", completedDetails);
        }

        [Authorize]
        public async Task<IActionResult> DeleteCompletedDetails(int id)
        {
            var deleteCompletedDetails = await _completedScalemodelsService.GetCompletedScalemodelDetailsAsync(id, _currentUser.GetUserId(User));

            return View("DeleteDetails", deleteCompletedDetails);
        }

        [Authorize]
        public async Task<IActionResult> CompletedDelete(int id)
        {
            await _completedScalemodelsService.CompletedDeleteAsync(id, _currentUser.GetUserId(User));
            return RedirectToAction("AllCompleted");
        }

        [Authorize]
        public async Task<IActionResult> EditCompletedDetails(int id, string returnUrl = null)
        {
            var editDetails = await _completedScalemodelsService.GetCompletedScalemodelDetailsAsync(id, _currentUser.GetUserId(User));

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
        public async Task<IActionResult> CompletedModelEdit(int id, CompletedScalemodelBindingModel model)
        {
            await _completedScalemodelsService.CompletedEditAsync(model, id, _currentUser.GetUserId(User));
            return RedirectToAction("AllCompleted");
        }
    }
}
