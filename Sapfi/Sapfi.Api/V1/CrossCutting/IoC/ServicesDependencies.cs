using Microsoft.Extensions.DependencyInjection;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using Sapfi.Api.V1.Services;

namespace Sapfi.Api.V1.CrossCutting.IoC
{
    public static class ServicesDependencies
    {
        public static void AddServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICalledTicketService, CalledTicketService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ILineFollowUpService, LineFollowUpService>();
            services.AddScoped<ILineService, LineService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ITicketFollowUpService, TicketFollowUpService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ILineStateService, LineStateService>();
        }
    }
}