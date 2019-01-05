using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Scalemodel.Data.Models;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services;
using ScalemodelWorld.Services.Scalemodels;
using ScalemodelWorld.Services.Scalemodels.Contracts;
using ScalemodelWorld.Services.SeedData;
using ScalemodelWorld.Services.SeedData.Contracts;
using ScalemodelWorld.Web.Middlewares.MiddlewareExtensions;
using ScalemodelWorld.Web.Utilities;

namespace ScalemodelWorld.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddDbContext<ScalemodelWorldContext>(options =>
                options.UseSqlServer(
                    this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<SeedDbContext>();

            services.AddIdentity<ScalemodelWorldUser, IdentityRole>(options =>
                   {
                       options.Password.RequiredLength = 6;
                       options.Password.RequireDigit = false;
                       options.Password.RequireLowercase = false;
                       options.Password.RequireNonAlphanumeric = false;
                       options.Password.RequireUppercase = false;
                   })
                .AddDefaultUI()
                   .AddEntityFrameworkStores<ScalemodelWorldContext>()
                   .AddDefaultTokenProviders();

            services.AddScoped<IUserClaimsPrincipalFactory<ScalemodelWorldUser>,
                UserClaimsPrincipalFactory<ScalemodelWorldUser, IdentityRole>>();

            services.AddAutoMapper();

            this.RegisterGlobalServices(services);

            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<UserManager<ScalemodelWorldUser>>();
            services.AddScoped<Logger<RegisterModel>>();
            services.AddTransient<UserResolverService>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
            services.AddScoped<ISeedDatabaseService, SeedDatabaseService>();
            services.AddAuthentication()
                .AddFacebook(facebbokOptions =>
                {
                    facebbokOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                    facebbokOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            Seeder.Seed(serviceProvider);
            //Use this as example for Middleware
            //app.UseSeedDataMiddleware();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        private void RegisterGlobalServices(IServiceCollection services)
        {
            services.AddScoped<IScalemodelsService, ScalemodelsService>();
        }
    }
}