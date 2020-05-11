using Microservice.Whatevers.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Microservice.Whatevers.Repositories.IoC
{
    public static class IoCRepositories
    {
        public static IServiceCollection AddRepository(this IServiceCollection services) =>
            services.Scan(x => x.FromExecutingAssembly().AddClasses(filter =>
                    filter.AssignableToAny(typeof(IRepository<,>)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
    }
}