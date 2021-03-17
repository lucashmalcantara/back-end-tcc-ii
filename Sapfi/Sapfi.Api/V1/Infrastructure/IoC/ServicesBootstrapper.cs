using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sapfi.Api.V1.Domain.Core.Interfaces.Repositories;
using Sapfi.Api.V1.Infrastructure.Persistence.Context;
using Sapfi.Api.V1.Infrastructure.Persistence.Repositories;

namespace Sapfi.Api.V1.Infrastructure.IoC
{
    public class RepositorysBootstrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICalledTicketRepository, CalledTicketRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ILineFollowUpRepository, LineFollowUpRepository>();
            services.AddScoped<ILineRepository, LineRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<ITicketFollowUpRepository, TicketFollowUpRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();

            //services.AddDbContext<SapfiDbContext>(options =>
            //    options.UseNpgsql(configuration.GetConnectionString("defaultConnection"), options => options.EnableRetryOnFailure()));
        }
    }
}