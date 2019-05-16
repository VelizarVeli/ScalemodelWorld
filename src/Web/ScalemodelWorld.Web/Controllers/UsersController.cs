using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scalemodel.Data.Models;
using ScalemodelWorld.Services.SeedData.Contracts;
using ScalemodelWorld.Web.ViewModels.Users;

namespace ScalemodelWorld.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly ISeedDatabaseService _seedDatabaseService;
        private readonly UserManager<ScalemodelWorldUser> _currentUser;

        public UsersController(ISeedDatabaseService seedDatabaseService,
            UserManager<ScalemodelWorldUser> current)
        {
            _seedDatabaseService = seedDatabaseService;
            _currentUser = current;
        }

        [Authorize]
        public IActionResult SeedPurchasedView()
        {
            return View("SeedPurchased");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SeedPurchased(SeedDataViewModel seedPath)
        {
            var pathString = seedPath.PathToJSONFile;
            await _seedDatabaseService.StartSeedingPurchasedAsync(_currentUser.GetUserId(User), pathString);

            return RedirectToAction("AllPurchased", "PurchasedScalemodels");
        }

        [Authorize]
        public IActionResult SeedStartedView()
        {
            return View("SeedStarted");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SeedStarted(SeedDataViewModel seedPath)
        {
            var pathString = seedPath.PathToJSONFile;
            await _seedDatabaseService.StartSeedingStartedAsync(_currentUser.GetUserId(User), pathString);

            return RedirectToAction("AllStarted", "StartedScalemodels");
        }

        [Authorize]
        public IActionResult SeedCompletedView()
        {
            return View("SeedCompleted");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SeedCompleted(SeedDataViewModel seedPath)
        {
            var pathString = seedPath.PathToJSONFile;
            await _seedDatabaseService.StartSeedingCompletedAsync(_currentUser.GetUserId(User), pathString);

            return RedirectToAction("AllCompleted", "CompletedScalemodels");
        }

        [Authorize]
        public IActionResult SeedWishlistView()
        {
            return View("SeedWishlist");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SeedWishList(SeedDataViewModel seedPath)
        {
            var pathString = seedPath.PathToJSONFile;
            await _seedDatabaseService.StartSeedingWishlistAsync(_currentUser.GetUserId(User), pathString);

            return RedirectToAction("AllWishlist", "Wishlist");
        }
    }
}