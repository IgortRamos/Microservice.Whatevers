using System;
using Microservice.Whatevers.Domain.Entities.Things;
using Xunit;

namespace Microservice.Whatevers.Domain.Tests.Entities.Builders
{
    public class ThingBuilderTests : EntitiesBuilderFixture<ThingBuilder, Thing, Guid>
    {
        private static string[] errors =
        {
            "O Identificador informado para Thing é inválido", 
            "O Nome informado para Thing é inválido",
            "O Tipo informado para Thing é inválido",
            "O Valor informado para Thing deve ser maior que zero",
        };

        [Fact]
        public void Build_should_throw() => AssertBuildThrowErros(errors);

        [Fact]
        public void Build_should_create_obj_whithout_erros() =>
            AssertBuildWithoutErros(x => x
                .WithId(Guid.NewGuid())
                .WithName("nome")
                .WithType("tipo")
                .WithValue(10));
    }
}