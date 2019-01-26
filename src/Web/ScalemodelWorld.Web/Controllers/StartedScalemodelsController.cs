﻿using System;
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
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.Scalemodels.Contracts;
using X.PagedList;

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
        public async Task<IActionResult> AllStarted(int? page)
        {
            var startededModels = await this.startedScalemodelsService.AllStarted(this.currentUser.GetUserId(User));
            var pageNumber = page ?? 1;
            var onePageOfProducts = startededModels.ToPagedList(pageNumber, 10);
            ViewBag.OnePageOfProducts = onePageOfProducts;

            return View("AllStarted");
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

            return RedirectToAction("AllCompleted", "CompletedScalemodels");
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
        public async Task<IActionResult> EditStartedDetails(int id, string returnUrl = null)
        {
            var editDetails = await this.startedScalemodelsService.GetStartedScalemodelDetailsAsync(id, this.currentUser.GetUserId(User));

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
           await this.startedScalemodelsService.StartedEditAsync(model, id, this.currentUser.GetUserId(User));
           return RedirectToAction("AllStarted");
       }
    }
}
