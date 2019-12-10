namespace Template.WebApp
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using FluentValidation.AspNetCore;

    using Application;
    using Infrastructure;
    using Persistence;
    using Template.Infrastructure;
    using Template.Application.Common.Interfaces;
    using Template.WebApp.Middleware;

    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure();
            services.AddPersistence(Configuration);
            services.AddApplication();

            services.AddHealthChecks()
                .AddDbContextCheck<TemplateDbContext>();

            services.AddHttpContextAccessor();            

            services
               .AddMvc(options => options.EnableEndpointRouting = false)
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ITemplateDbContext>())
               .AddRazorPagesOptions(options => options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout"));

            services.AddControllersWithViews();

            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseCustomExceptionHandler();
            app.UseHealthChecks("/health");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvcWithAreas();
        }
    }
}
