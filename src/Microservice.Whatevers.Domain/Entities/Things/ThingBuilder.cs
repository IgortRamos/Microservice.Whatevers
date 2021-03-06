using System;
using Microservice.Whatevers.Domain.Abstractions.Builders;
using Microservice.Whatevers.Domain.Extensions;

namespace Microservice.Whatevers.Domain.Entities.Things
{
    public class ThingBuilder : Builder<ThingBuilder, Thing, Guid>
    {
        private string _name;
        private string _type;
        private double _value;

        public ThingBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ThingBuilder WithType(string type)
        {
            _type = type;
            return this;
        }

        public ThingBuilder WithValue(double value)
        {
            _value = value;
            return this;
        }
        
        public override Things.Thing Build() => new Thing(Id,  _name, _type, _value).ThrowIfHasErros();
    }
}