using Microsoft.Extensions.DependencyInjection;
using Application.Application.Common.Interfaces;
using Application.Common.Interfaces;

namespace Application.Infrastructure
{
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