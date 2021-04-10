using Microsoft.EntityFrameworkCore;
using Sapfi.Api.V1.Domain.Entities;
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

            builder.Entity<Address>().ToTable("address").HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<CalledTicket>().ToTable("called_ticket").HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Company>().ToTable("company").HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Line>().ToTable("line").HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<LineFollowUp>().ToTable("line_follow_up").HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Notification>().ToTable("notification").HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Ticket>().ToTable("ticket").HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<TicketFollowUp>().ToTable("ticket_follow_up").HasQueryFilter(p => !p.IsDeleted);

            base.OnModelCreating(builder);
        }
    }
}