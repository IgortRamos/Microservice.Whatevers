using System;
using Microservice.Whatevers.Domain.Abstractions.Builders;
using Microservice.Whatevers.Domain.Extensions;

namespace Microservice.Whatevers.Domain.Entities.Whatevers
{
    public class WhateverBuilder : Builder<WhateverBuilder, Whatever, Guid>
    {
        private string _name;
        private DateTime _time;
        private string _type;

        public WhateverBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public WhateverBuilder WithType(string type)
        {
            _type = type;
            return this;
        }

        public WhateverBuilder WithTime(DateTime time)
        {
            _time = time;
            return this;
        }

        public override Whatever Build() => new Whatever(Id, _name, _time, _type);
    }
}