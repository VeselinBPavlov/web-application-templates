namespace Application.WebApp.Infrastructure
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
                using(var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    ApplicationInitializer.Initialize(context);
                }
            }    

            return app;
        }
        
        
        public static IApplicationBuilder UseMvcWithAreas(this IApplicationBuilder app)
            => app.UseEndpoints(endpoints =>
            {
             endpoints.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}");
            
             endpoints.MapAreaControllerRoute(
              name: "areas", "areas",
              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
             endpoints.MapRazorPages();
            });
    }
}