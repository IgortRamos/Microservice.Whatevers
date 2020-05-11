using System;
using FluentAssertions;
using Microservice.Whatevers.Domain.Abstractions;
using Microservice.Whatevers.Domain.Exceptions;
using Microservice.Whatevers.Domain.Extensions;
using Xunit;

namespace Microservice.Whatevers.Domain.Tests.Extensions
{
    public class NotificationExtensionsTests
    {
        [Fact]
        public void ThrowIfHasErros_should_throw()
        {
            var expectedErrorMessage = Guid.NewGuid().ToString();
            var entityTest = new EntityTest();
            entityTest.AddError(expectedErrorMessage);
            Action actual = () => entityTest.ThrowIfHasErros();
            actual.Should().Throw<BusinessException>().WithMessage(expectedErrorMessage);
        }
        
        [Fact]
        public void ThrowIfHasErros_should_not_throw()
        {
            var entityTest = new EntityTest();
            Action actual = () => entityTest.ThrowIfHasErros();
            actual.Should().NotThrow<BusinessException>();
        }
        
        [Fact]
        public void ThrowIfHasErros_should_return_parameter_obj()
        {
            var entityTest = new EntityTest();
            var actual = entityTest.ThrowIfHasErros();
            actual.Should().BeSameAs(entityTest);
        }
    }

    public class EntityTest : EntityBase<Guid> { }
}