using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microservice.Whatevers.Domain.Abstractions;
using Microservice.Whatevers.Repositories.Abstractions;
using Microservice.Whatevers.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Whatevers.Services.Abstractions
{
    public abstract class Service<TEntity, TModel, TId> : IService<TEntity, TModel, TId>
        where TEntity : EntityBase<TId>
        where TModel : Model
        where TId : struct
    {
        private readonly IRepository<TEntity, TId> _repository;
        private readonly IMapper _mapper;

        protected Service(IRepository<TEntity, TId> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public virtual Task DeleteAsync(TId id, CancellationToken cancellationToken) => 
            Equals(id, Guid.Empty) 
                ? Task.CompletedTask 
                : _repository.DeleteAsync(id, cancellationToken);

        public virtual async Task<TEntity> EditAsync(TModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(model);
            if (entity.IsValid()) 
                await _repository.UpdateAsync(entity, cancellationToken);
            return entity;
        }

        public virtual Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken) => 
            _repository.ExistsAsync(id, cancellationToken);

        public virtual Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken) => 
            _repository.SelectAll().ToListAsync(cancellationToken);

        public virtual Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken) => 
            _repository.SelectByIdAsync(id, cancellationToken);

        public virtual async Task<TEntity> SaveAsync(TModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(model);
            if(entity.IsValid()) await _repository.InsertAsync(entity, cancellationToken);
            return entity;
        }
    }
}