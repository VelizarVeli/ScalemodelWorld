using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scalemodel.Data.Models;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Services.Scalemodels.Contracts;
using X.PagedList;

namespace ScalemodelWorld.Web.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IWishlistService _wishlistService;
        private readonly UserManager<ScalemodelWorldUser> _currentUser;

        public WishlistController(IWishlistService wishlistService,
            UserManager<ScalemodelWorldUser> current)
        {
            _wishlistService = wishlistService;
            _currentUser = current;
        }



        [Authorize]
       public async Task<IActionResult> AllWishlist(int? page)
       {
           var wishlistModels = await _wishlistService.WishlistAll(_currentUser.GetUserId(User));
           var pageNumber = page ?? 1;
           var onePageOfProducts = wishlistModels.ToPagedList(pageNumber, 10);
           ViewBag.OnePageOfProducts = onePageOfProducts;

            return View("AllWishlist");
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
            await _wishlistService.AddWishAsync(model, _currentUser.GetUserId(User));

            return RedirectToAction("AllWishlist");
        }
    }
}