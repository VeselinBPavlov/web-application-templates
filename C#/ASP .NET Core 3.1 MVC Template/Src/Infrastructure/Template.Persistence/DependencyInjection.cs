namespace Template.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Application.Common.Interfaces;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TemplateDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TemplateDbConnection")));

            services.AddScoped<ITemplateDbContext>(provider => provider.GetService<TemplateDbContext>());
            
            return services;
        }
    }
}