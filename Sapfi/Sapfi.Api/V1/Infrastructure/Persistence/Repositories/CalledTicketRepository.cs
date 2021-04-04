using Sapfi.Api.V1.Domain.Core.Entities;
using Sapfi.Api.V1.Domain.Core.Interfaces.Repositories;
using Sapfi.Api.V1.Infrastructure.Persistence.Context;
using Sapfi.Api.V1.Infrastructure.Persistence.Repositories.Base;

namespace Sapfi.Api.V1.Infrastructure.Persistence.Repositories
{
    public class CalledTicketRepository : EntityRepository<CalledTicket>, ICalledTicketRepository
    {
        public CalledTicketRepository(SapfiDbContext context) : base(context)
        {
        }
    }
}
