using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scalemodel.Data.Models;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.SeedData.Contracts;

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
        public async Task<IActionResult> Seeding()
        {
            await this.seedDatabaseService.StartSeedingAsync(this.currentUser.GetUserId(User));

            return RedirectToAction("AllWishlist", "Wishlist");
        }
    }
}