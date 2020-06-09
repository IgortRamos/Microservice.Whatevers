using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Domain.Abstractions;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Abstractions
{
    public interface IService<TEntity, TModel, TId>
        where TEntity : EntityBase<TId>
        where TModel : Model
        where TId : struct
    {
        Task DeleteAsync(TId id, CancellationToken cancellationToken);
        Task<TEntity> EditAsync(TModel model, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken);
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken);
        Task<TEntity> SaveAsync(TModel model, CancellationToken cancellationToken);
    }
}