using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Template.WebApp.Areas.Identity.IdentityHostingStartup))]
namespace Template.WebApp.Areas.Identity
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