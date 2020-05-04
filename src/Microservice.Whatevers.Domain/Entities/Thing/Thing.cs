using System;
using Microservice.Whatevers.Domain.Abstractions;

namespace Microservice.Whatevers.Domain.Entities.Thing
{
    public class Thing : EntityBase<Guid>
    {
        internal Thing(Guid id, string name, string type, double value)
        {
            SetId(id);
            SetName(name);
            SetType(type);
            SetValue(value);
        }
        
        public string Name { get; private set; }
        public string Type { get; private set; }
        public double Value { get; private set; }
        
        protected sealed override void SetId(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                AddError(Resources.Thing_Identifier_invalid);
                return;
            }

            base.SetId(id);
        }
        
        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                AddError(Resources.Thing_Name_invalid);
                return;
            }

            Name = name;
        }

        private void SetType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                AddError(Resources.Thing_Type_invalid);
                return;
            }

            Type = type;
        }

        private void SetValue(double value)
        {
            if (value <= 0)
            {
                AddError(Resources.Thing_Value_less_than_zero);
                return;
            }

            Value = value;
        }
    }
}