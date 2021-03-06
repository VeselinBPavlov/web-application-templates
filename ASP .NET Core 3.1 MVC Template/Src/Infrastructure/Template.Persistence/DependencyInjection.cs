namespace Template.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Application.Common.Interfaces;
    using Template.Domain.Entities;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TemplateDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TemplateDbConnection")));

            services.AddScoped<ITemplateDbContext>(provider => provider.GetService<TemplateDbContext>());

            services.AddDefaultIdentity<TemplateUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
                .AddRoles<TemplateRole>()
                .AddEntityFrameworkStores<TemplateDbContext>();
            

            services.AddScoped<ITemplateDbContext>(provider => provider.GetService<TemplateDbContext>());

            return services;
        }
    }
}