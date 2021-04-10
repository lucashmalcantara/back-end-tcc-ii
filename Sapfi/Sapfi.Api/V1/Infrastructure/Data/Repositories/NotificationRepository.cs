using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Repositories;
using Sapfi.Api.V1.Infrastructure.Data.Context;
using Sapfi.Api.V1.Infrastructure.Data.Repositories.Base;

namespace Sapfi.Api.V1.Infrastructure.Data.Repositories
{
    public class NotificationRepository : EntityRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(SapfiDbContext context) : base(context)
        {
        }
    }
}
