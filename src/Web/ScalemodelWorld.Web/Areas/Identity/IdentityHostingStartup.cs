using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ScalemodelWorld.Web.Areas.Identity.IdentityHostingStartup))]
namespace ScalemodelWorld.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}