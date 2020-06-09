using AutoMapper;
using Microservice.Whatevers.Services.Abstractions;
using Microservice.Whatevers.Services.Clients;
using Microservice.Whatevers.Services.Mappers;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Microservice.Whatevers.Services.IoC
{
    public static class IoCServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services
                .Scan(x => x.FromCallingAssembly().AddClasses(filter =>
                    filter.AssignableToAny(typeof(IService<,,>)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        public static IServiceCollection AddAutoMapper(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(ModelToDomainProfile), typeof(DomainToModelProfile))
                .AddScoped<IGoogleService, GoogleService>()
                .AddScoped<IGoogleClient, GoogleClient>();
    }
}