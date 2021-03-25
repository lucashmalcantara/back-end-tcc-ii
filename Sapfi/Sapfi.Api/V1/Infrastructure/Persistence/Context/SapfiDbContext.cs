using Microsoft.EntityFrameworkCore;
using Sapfi.Api.V1.Domain.Core.Entities;
using System.Reflection;

namespace Sapfi.Api.V1.Infrastructure.Persistence.Context
{
    public class SapfiDbContext : DbContext
    {
        public SapfiDbContext(DbContextOptions<SapfiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<Address>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<CalledTicket>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Company>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Line>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<LineFollowUp>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Notification>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Ticket>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<TicketFollowUp>().HasQueryFilter(p => !p.IsDeleted);

            base.OnModelCreating(builder);
        }
    }
}