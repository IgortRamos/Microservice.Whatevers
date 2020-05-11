using System;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microservice.Whatevers.Repositories.Abstractions;

namespace Microservice.Whatevers.Repositories
{
    public class WhateverRepository : Repository<Whatever, Guid>, IWhateverRepository
    {
        public WhateverRepository() : base() { }
    }
}