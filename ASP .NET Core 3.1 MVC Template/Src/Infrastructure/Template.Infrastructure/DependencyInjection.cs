namespace Template.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;

    using Application.Common.Interfaces;
    using Common.Interfaces;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();
            
            return services;
        }
    }
}