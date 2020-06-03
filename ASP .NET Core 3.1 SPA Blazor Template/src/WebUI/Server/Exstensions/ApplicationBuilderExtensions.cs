using Microsoft.AspNetCore.Builder;

namespace Template.WebUI.Server.Exstensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseEndpointsWithAreas(this IApplicationBuilder app)
            => app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                //endpoints.MapControllerRoute(
                //    name: "areas",
                //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
    }
}
