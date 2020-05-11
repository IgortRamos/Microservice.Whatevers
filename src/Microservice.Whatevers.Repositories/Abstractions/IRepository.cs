using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Domain.Abstractions;

namespace Microservice.Whatevers.Repositories.Abstractions
{
    public interface IRepository<TEntity, in TId>
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        Task DeleteAsync(TId id, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken);
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> SelectByIdAsync(TId id, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity, CancellationToken cancelletionToken);
    }
}