using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScalemodelWorld.Web.Services.Contracts;
using ScalemodelWorld.Web.ViewModels.Home;
using ScalemodelWorld.Web.ViewModels.Scalemodels;

namespace ScalemodelWorld.Web.Controllers
{
    public class ScalemodelsController : BaseController
    {
        private readonly IScalemodelService scalemodelService;

        public ScalemodelsController(IScalemodelService scalemodelService)
        {
            this.scalemodelService = scalemodelService;
        }

        public IActionResult StartedModels()
        {
            var model = this.Db.StartedScalemodels.Select(x =>
                new BaseScalemodelViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            var models = new LoggedInIndexViewModel { Started = model };
            return View("_LoginPartial", models);
        }

        [Authorize]
        public IActionResult _LoginPartial()
        {
            var model = new LoggedInIndexViewModel {Started = this.scalemodelService.All()};
            return this.View(model);
        }
    }
}
