using System;
using Microservice.Whatevers.Domain.Entities.Things;
using Microservice.Whatevers.Repositories.Abstractions;
using Microservice.Whatevers.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Microservice.Whatevers.Repositories.IoC
{
    public static class IoCRepositories
    {
        private static readonly RepositoriesOptions _repositoriesOptions = new RepositoriesOptions();
        
        public static IServiceCollection AddDbContext(this IServiceCollection services, Action<RepositoriesOptions> options)
        {
            options(_repositoriesOptions);

            return services.AddDbContext<WhateverContext>(dbContextOptions
                => dbContextOptions
                    .UseInMemoryDatabase(_repositoriesOptions.ConnectionString));
        }

        public static IServiceCollection AddRepository(this IServiceCollection services) =>
            services
                .Scan(x => x.FromCallingAssembly().AddClasses(filter =>
                    filter.AssignableToAny(typeof(IRepository<,>)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
    }
}