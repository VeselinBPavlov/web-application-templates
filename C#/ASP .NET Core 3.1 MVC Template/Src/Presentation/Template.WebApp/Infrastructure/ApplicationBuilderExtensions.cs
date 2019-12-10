namespace Template.WebApp.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    using Persistence;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using var context = serviceScope.ServiceProvider.GetRequiredService<TemplateDbContext>();
                ApplicationInitializer.Initialize(context);
            }

            return app;
        }


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