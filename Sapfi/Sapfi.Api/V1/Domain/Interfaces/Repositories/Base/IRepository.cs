using Sapfi.Api.V1.Domain.Entities.Interfaces;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Interfaces.Repositories.Base
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        void Save();
        Task SaveAsync();
        void Dispose();
    }
}