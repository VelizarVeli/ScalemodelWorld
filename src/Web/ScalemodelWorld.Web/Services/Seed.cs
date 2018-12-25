using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScalemodelWorld.Web.Areas.Identity.Data;

namespace ScalemodelWorld.Web.Services
{
    public static class Seed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {

            //adding customs roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ScalemodelWorldUser>>();
            string[] roleNames = { "Admin", "Manager", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                // creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // creating a super user who could maintain the web app
            var poweruser = new ScalemodelWorldUser
            {
                UserName = Configuration.GetSection("AppSettings")["UserEmail"],
                Email = Configuration.GetSection("AppSettings")["UserEmail"]
            };

            string userPassword = Configuration.GetSection("AppSettings")["UserPassword"];
            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("AppSettings")["UserEmail"]);

            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    // here we assign the new user the "Admin" role 
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }
    }
}