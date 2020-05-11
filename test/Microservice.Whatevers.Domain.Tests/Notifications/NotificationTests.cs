using System.Collections.Generic;
using FluentAssertions;
using Microservice.Whatevers.Domain.Abstractions.Notifications;
using Xunit;

namespace Microservice.Whatevers.Domain.Tests.Notifications
{
    public class NotificationTests
    {
        private readonly INotification _entityTest;
        
        public NotificationTests()
        {
            _entityTest = new EntityTest();
        }
        
        [Theory]
        [InlineData("Erro1")]
        [InlineData("Erro1","erro2")]
        [InlineData("Erro1","erro2","outro ERRO")]
        public void GetError_from_AddError(params string[] expected)
        {
            SetupAddError(expected);
            _entityTest.GetError().Should().Be(string.Join("; ", expected));
            _entityTest.IsValid().Should().BeFalse();
        }

        [Theory]
        [InlineData("Erro1")]
        [InlineData("Erro1","erro2")]
        [InlineData("Erro1","erro2","outro ERRO")]
        public void GetErrors_from_AddError(params string[] expected)
        {
            SetupAddError(expected);
            _entityTest.GetErrors().Should().BeEquivalentTo(expected);
            _entityTest.IsValid().Should().BeFalse();
        }

        [Theory]
        [InlineData("Erro1")]
        [InlineData("Erro1","erro2")]
        [InlineData("Erro1","erro2","outro ERRO")]
        public void GetError_from_AddErrors(params string[] expected)
        {
            _entityTest.AddErrors(expected);
            _entityTest.GetError().Should().Be(string.Join("; ", expected));
            _entityTest.IsValid().Should().BeFalse();
        }

        [Theory]
        [InlineData("Erro1")]
        [InlineData("Erro1","erro2")]
        [InlineData("Erro1","erro2","outro ERRO")]
        public void GetErrors_from_AddErrors(params string[] expected)
        {
            _entityTest.AddErrors(expected);
            _entityTest.GetErrors().Should().BeEquivalentTo(expected);
            _entityTest.IsValid().Should().BeFalse();
        }

        [Fact]
        public void IsValid_should_be_true_with_no_erros()
        {
            _entityTest.IsValid().Should().BeTrue();
            _entityTest.GetError().Should().BeEmpty();
            _entityTest.GetErrors().Should().BeEmpty();
        }

        private void SetupAddError(IEnumerable<string> expected)
        {
            foreach (var errorMessage in expected)
                _entityTest.AddError(errorMessage);
        }
    }
    
    public class EntityTest : Notification { }
}