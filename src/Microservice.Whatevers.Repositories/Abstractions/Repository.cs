using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Domain.Abstractions;

namespace Microservice.Whatevers.Repositories.Abstractions
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        protected Repository()
        {
        }

        public Task DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken)
        {
            return Task.FromResult(false);
        }

        public Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<TEntity> SelectByIdAsync(TId id, CancellationToken cancellationToken)
        {
            return Task.FromResult<TEntity>(null);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancelletionToken)
        {
            return Task.CompletedTask;
        }
    }
}