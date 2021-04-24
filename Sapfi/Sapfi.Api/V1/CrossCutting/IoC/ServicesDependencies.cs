using Microsoft.Extensions.DependencyInjection;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using Sapfi.Api.V1.Services;

namespace Sapfi.Api.V1.CrossCutting.IoC
{
    public static class ServicesDependencies
    {
        public static void AddServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ILineFollowUpService, LineFollowUpService>();
            services.AddTransient<ILineService, LineService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<ITicketFollowUpService, TicketFollowUpService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<ILineStateService, LineStateService>();
        }
    }
}