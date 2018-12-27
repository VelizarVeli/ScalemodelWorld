using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScalemodelWorld.Web.Models;

namespace ScalemodelWorld.Web.Controllers
{
    public class HomeController : BaseController
    {
        //private readonly UserManager<IdentityUser> userManager;
        //private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(/*UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager*/)
        {
        //    this.userManager = userManager;
        //    this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            //var userInfo = await this.userManager.GetUserAsync(this.User);
            //await this.roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
            //await this.userManager.AddToRoleAsync(userInfo, "Admin");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ViewResult MyView()
        {
            return View("MyView");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
