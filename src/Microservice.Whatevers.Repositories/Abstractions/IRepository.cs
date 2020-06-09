using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Domain.Abstractions;
using Microservice.Whatevers.Domain.Entities.Whatevers;

namespace Microservice.Whatevers.Repositories.Abstractions
{
    public interface IRepository<TEntity, in TId>
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        Task DeleteAsync(TId id, CancellationToken cancellationToken);

        Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken);

        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);

        IQueryable<TEntity> SelectAll();

        Task<TEntity> SelectByIdAsync(TId id, CancellationToken cancellationToken);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    }
}