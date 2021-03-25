using Microsoft.Extensions.DependencyInjection;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using Sapfi.Api.V1.Domain.Services;

namespace Sapfi.Api.V1.Infrastructure.IoC
{
    public class RepositoriesBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICalledTicketService, CalledTicketService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ILineFollowUpService, LineFollowUpService>();
            services.AddScoped<ILineService, LineService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ITicketFollowUpService, TicketFollowUpService>();
            services.AddScoped<ITicketService, TicketService>();
        }
    }
}
