using Sapfi.Api.V1.Domain.Core.Entities.Interfaces;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Repositories.Base
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        void Create(TEntity entity, string createdBy = null);
        void Update(TEntity entity, string modifiedBy = null);
        void Delete(object id);
        void Delete(TEntity entity);
        void Save();
        Task SaveAsync();
        void Dispose();
    }
}