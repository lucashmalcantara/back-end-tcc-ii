using Microsoft.EntityFrameworkCore;
using Sapfi.Api.V1.Domain.Entities.Interfaces;
using Sapfi.Api.V1.Domain.Interfaces.Repositories.Base;
using System;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Infrastructure.Data.Repositories.Base
{
    public class EntityRepository<TEntity>
        : EntityReadOnlyRepository<TEntity>, IRepository<TEntity> where TEntity : class, IEntity
    {
        public EntityRepository(DbContext context) : base(context)
        {
        }

        public virtual void Create(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            _context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity entity = _context.Set<TEntity>().Find(id);
            
            if (entity == null)
                return;

            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public virtual void Save() => _context.SaveChanges();

        public virtual async Task SaveAsync() => await _context.SaveChangesAsync();

        public virtual void Dispose() => _context.Dispose();
    }
}