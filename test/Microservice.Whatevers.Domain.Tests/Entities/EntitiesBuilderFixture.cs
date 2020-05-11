using System;
using FluentAssertions;
using Microservice.Whatevers.Domain.Abstractions;
using Microservice.Whatevers.Domain.Abstractions.Builders;
using Microservice.Whatevers.Domain.Exceptions;

namespace Microservice.Whatevers.Domain.Tests.Entities
{
    public abstract class EntitiesBuilderFixture<TBuilder, TEntity, TId>
        where TBuilder : Builder<TBuilder, TEntity, TId>, new()
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        protected void AssertBuildThrowErros(params string[] errors)
        {
            var builder = new TBuilder();
            Action actual = () => builder.Build();
            actual.Should().Throw<BusinessException>().WithMessage(string.Join("; ", errors));
        }
        
        protected void AssertBuildErros(params string[] errors)
        {
            var builder = new TBuilder();
            builder.Build().GetErrors().Should().BeEquivalentTo(errors);
        }
        
        protected void AssertBuildWithoutErros(Func<TBuilder, TBuilder> builder) => 
            builder(new TBuilder())
                .Build()
                .IsValid()
                .Should()
                .BeTrue();
    }
}