using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scalemodel.Data.Models;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.Scalemodels.Contracts;

namespace ScalemodelWorld.Web.Controllers
{
    public class WishlistController : Controller
    {
        private readonly ScalemodelWorldContext db;
        private readonly IWishlistService wishlistService;
        private readonly UserManager<ScalemodelWorldUser> currentUser;

        public WishlistController(ScalemodelWorldContext db,
            IWishlistService wishlistService,
            UserManager<ScalemodelWorldUser> current)
        {
            this.db = db;
            this.wishlistService = wishlistService;
            this.currentUser = current;
        }

        [Authorize]
       public async Task<IActionResult> AllWishlist()
       {
           var wishlistModels = await this.wishlistService.WishlistAll(this.currentUser.GetUserId(User));

           return View("AllWishlist", wishlistModels);
       }

        [Authorize]
        public IActionResult AddWishModel()
        {
            return View("AddWishModel");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddWishModel(WishlistScalemodelBindingModel model)
        {
            await this.wishlistService.AddWishAsync(model, this.currentUser.GetUserId(User));

            return RedirectToAction("AllWishlist");
        }
    }
}