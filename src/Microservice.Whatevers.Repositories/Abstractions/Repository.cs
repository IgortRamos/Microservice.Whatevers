using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Whatevers.Repositories.Abstractions
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        
        protected Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            var entidade = await SelectByIdAsync(id, cancellationToken).ConfigureAwait(false);
            
            if(entidade == default)
                return;
            
            _dbSet.Remove(entidade);
            await _context.SaveChangesAsync(true, cancellationToken);
        }

        public virtual Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken) =>
            _dbSet.AsNoTracking().AnyAsync(x => x.Id.Equals(id), cancellationToken);

        public virtual async Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if(await ExistsAsync(entity.Id, cancellationToken).ConfigureAwait(false)) return;

            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(true, cancellationToken);
        }

        public virtual IQueryable<TEntity> SelectAll() => _dbSet;

        public virtual Task<TEntity> SelectByIdAsync(TId id, CancellationToken cancellationToken) => 
            _dbSet.FirstAsync(x => x.Id.Equals(id), cancellationToken);

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if(await ExistsAsync(entity.Id, cancellationToken).ConfigureAwait(false)) return;

            _dbSet.Update(entity);
            await _context.SaveChangesAsync(true, cancellationToken);
        }
    }
}