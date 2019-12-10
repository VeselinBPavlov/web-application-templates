namespace Template.WebApp.Infrastructure
{
    using Microsoft.AspNetCore.Builder;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMvcWithAreas(this IApplicationBuilder app)
            => app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "Administrator",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
    }
}