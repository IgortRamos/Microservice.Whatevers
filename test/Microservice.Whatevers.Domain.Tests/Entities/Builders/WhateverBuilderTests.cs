using System;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Xunit;

namespace Microservice.Whatevers.Domain.Tests.Entities.Builders
{
    public class WhateverBuilderTests : EntitiesBuilderFixture<WhateverBuilder,  Whatever, Guid>
    {
        private static string[] errors =
        {
            "O Identificador informado para Whatever é inválido", 
            "O Nome informado para Whatever é inválido",
            "O Tempo informado para Whatever é inválido",
            "O Tipo informado para Whatever é inválido",
        };

        [Fact]
        public void Build_should_contain_erros() => AssertBuildErros(errors);
        
        [Fact]
        public void Build_should_create_obj_whithout_erros() =>
            AssertBuildWithoutErros(x => x
                .WithId(Guid.NewGuid())
                .WithName("nome")
                .WithTime(DateTime.Now)
                .WithType("tipo"));
    }
}