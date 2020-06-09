using System;
using System.Collections.Generic;
using System.Linq;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microservice.Whatevers.Repositories.Abstractions;
using Microservice.Whatevers.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Whatevers.Repositories
{
    public class WhateverRepository : Repository<Whatever, Guid>, IWhateverRepository
    {
        public WhateverRepository(WhateverContext whateverContext) : base(whateverContext) { }
        
        public IQueryable<Whatever> SelectAllWithThing() => SelectAll().Include(x => x.Things);
    }
}