using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sapfi.Api.V1.Domain.Interfaces.Repositories;
using Sapfi.Api.V1.Infrastructure.Data.Context;
using Sapfi.Api.V1.Infrastructure.Data.Repositories;

namespace Sapfi.Api.V1.CrossCutting.IoC
{
    public static class RepositoriesDependencies
    {
        public static void AddRepositoriesDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ILineFollowUpRepository, LineFollowUpRepository>();
            services.AddTransient<ILineRepository, LineRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<ITicketFollowUpRepository, TicketFollowUpRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddDbContext<SapfiDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("Default")), ServiceLifetime.Transient, ServiceLifetime.Transient);
        }
    }
}
