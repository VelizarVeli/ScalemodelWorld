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
    public class PurchasedScalemodelsController : Controller
    {
        private readonly IPurchasedScalemodelsService _purchasedScalemodelsService;
        private readonly UserManager<ScalemodelWorldUser> _currentUser;

        public PurchasedScalemodelsController(IPurchasedScalemodelsService purchasedScalemodelsService,
            UserManager<ScalemodelWorldUser> current)
        {
            _purchasedScalemodelsService = purchasedScalemodelsService;
            _currentUser = current;
        }

        [Authorize]
        public async Task<IActionResult> AllPurchased(int? page)
        {
            var purchasedModels = await _purchasedScalemodelsService.AllPurchased(_currentUser.GetUserId(User));
            var pageNumber = page ?? 1;
            var onePageOfProducts = purchasedModels.ToPagedList(pageNumber, 10);
            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View("AllPurchased");
        }

        [Authorize]
        public IActionResult AddModel(string returnUrl = null)
        {
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

            return View("AddModel");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddScalemodel(PurchasedScalemodelBindingModel model)
        {
            await _purchasedScalemodelsService.AddPurchasedAsync(model, _currentUser.GetUserId(User));

            return RedirectToAction("AllPurchased");
        }

       [Authorize]
       public async Task<IActionResult> PurchasedDetails(int id)
       {
           var purchasedDetails =
               await _purchasedScalemodelsService.GetPurchasedScalemodelDetailsAsync(id, _currentUser.GetUserId(User));
           if (purchasedDetails == null)
           {
               return RedirectToAction(ActionConstants.Purchased);
           }

           return View("PurchasedModelDetails", purchasedDetails);
       }

        [Authorize]
        public async Task<IActionResult> StartNewBuild(int id)
        {
            await _purchasedScalemodelsService.StartNewBuildAsync(id, _currentUser.GetUserId(User));

            return RedirectToAction("AllStarted","StartedScalemodels");
        }

        [Authorize]
        public async Task<IActionResult> DeleteDetails(int id)
        {
            var deleteDetails = await _purchasedScalemodelsService.GetPurchasedScalemodelDetailsAsync(id, _currentUser.GetUserId(User));

            return View("DeleteDetails", deleteDetails);
        }

        [Authorize]
        public async Task<IActionResult> PurchasedDelete(int id)
        {
            await _purchasedScalemodelsService.PurchasedDeleteAsync(id, _currentUser.GetUserId(User));
            return RedirectToAction("AllPurchased");
        }

        [Authorize]
        public async Task<IActionResult> EditDetails(int id, string returnUrl = null)
        {
            var editDetails = await _purchasedScalemodelsService.GetPurchasedScalemodelDetailsAsync(id, _currentUser.GetUserId(User));

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
        public async Task<IActionResult> PurchasedEdit(int id, PurchasedScalemodelBindingModel model)
        {
            await _purchasedScalemodelsService.PurchasedEditAsync(model, id, _currentUser.GetUserId(User));
            return RedirectToAction("AllPurchased");
        }
    }
}