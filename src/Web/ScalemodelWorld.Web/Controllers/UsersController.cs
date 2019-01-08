using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scalemodel.Data.Models;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.SeedData.Contracts;
using ScalemodelWorld.Web.ViewModels.Users;

namespace ScalemodelWorld.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly ScalemodelWorldContext db;
        private readonly ISeedDatabaseService seedDatabaseService;
        private readonly UserManager<ScalemodelWorldUser> currentUser;

        public UsersController(ScalemodelWorldContext db,
            ISeedDatabaseService seedDatabaseService,
            UserManager<ScalemodelWorldUser> current)
        {
            this.db = db;
            this.seedDatabaseService = seedDatabaseService;
            this.currentUser = current;
        }

        [Authorize]
        public IActionResult UserControlPanel()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> SeedPurchased(SeedDataViewModel seedPath)
        {
            var pathString = seedPath.PathToJSONFile;
            var category = seedPath.Category;
            await this.seedDatabaseService.StartSeedingAsync(this.currentUser.GetUserId(User), pathString, category.ToString());

            return RedirectToAction("AllPurchased", "PurchasedScalemodels");
        }

        [Authorize]
        public async Task<IActionResult> SeedStarted(SeedDataViewModel seedPath)
        {
            var pathString = seedPath.PathToJSONFile;
            var category = seedPath.Category;
            await this.seedDatabaseService.StartSeedingAsync(this.currentUser.GetUserId(User), pathString, category.ToString());

            return RedirectToAction("AllStarted", "StartedScalemodels");
        }

        [Authorize]
        public async Task<IActionResult> SeedCompleted(SeedDataViewModel seedPath)
        {
            var pathString = seedPath.PathToJSONFile;
            var category = seedPath.Category;
            await this.seedDatabaseService.StartSeedingAsync(this.currentUser.GetUserId(User), pathString, category.ToString());

            return RedirectToAction("AllCompleted", "CompletedScalemodels");
        }

        [Authorize]
        public async Task<IActionResult> SeedWishList(SeedDataViewModel seedPath)
        {
            var pathString = seedPath.PathToJSONFile;
            var category = seedPath.Category;
            await this.seedDatabaseService.StartSeedingAsync(this.currentUser.GetUserId(User), pathString, category.ToString());

            return RedirectToAction("AllWishlist", "Wishlist");
        }
    }
}