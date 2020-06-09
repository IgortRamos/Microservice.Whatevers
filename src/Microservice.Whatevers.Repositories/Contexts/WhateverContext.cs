using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Domain.Entities.Things;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Whatevers.Repositories.Contexts
{
    public class WhateverContext : DbContext
    {
        public WhateverContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Whatever> Whatevers { get; set; }
        public DbSet<Thing> Things { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WhateverContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}