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
            services.AddScoped<ICalledTicketRepository, CalledTicketRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ILineFollowUpRepository, LineFollowUpRepository>();
            services.AddScoped<ILineRepository, LineRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<ITicketFollowUpRepository, TicketFollowUpRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddDbContext<SapfiDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("Default")));
        }
    }
}
