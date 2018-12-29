using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ScalemodelWorld.Web.Utilities
{
    public static class Seeder
    {
        public static void Seed(IServiceProvider provider)
        {
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();
            var adminRoleExists = roleManager.RoleExistsAsync("Admin").Result;
            if (!adminRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("Admin"));
            }
        }
    }
}