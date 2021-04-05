using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using Sapfi.Api.V1.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Sapfi.Api.V1.Infrastructure.Persistence.Context;

namespace Sapfi.Api.V1.Infrastructure.IoC
{
    public class RepositoriesBootstrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICalledTicketService, CalledTicketService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ILineFollowUpService, LineFollowUpService>();
            services.AddScoped<ILineService, LineService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ITicketFollowUpService, TicketFollowUpService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddDbContext<SapfiDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("Default")));
        }
    }
}
