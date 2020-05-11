using System;
using System.Collections.Generic;
using Microservice.Whatevers.Domain.Abstractions;
using Microservice.Whatevers.Domain.Entities.Things;

namespace Microservice.Whatevers.Domain.Entities.Whatevers
{
    public class Whatever : EntityBase<Guid>
    {
        internal Whatever(Guid id, string name, DateTime time, string type)
        {
            SetId(id);
            SetName(name);
            SetTime(time);
            SetType(type);
            Things = new List<Thing>();
        }

        public string Name { get; private set; }
        public virtual ICollection<Thing> Things { get; }
        public DateTime Time { get; private set; }
        public string Type { get; private set; }

        public void AddThing(Thing thing)
        {
            if (thing == default) return;

            if (!thing.IsValid())
            {
                AddError(Resources.Whatever_Thing_invalid);
                AddErrors(thing.GetErrors());
                return;
            }

            Things.Add(thing);
        }

        protected sealed override void SetId(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                AddError(Resources.Whatever_Identifier_invalid);
                return;
            }

            base.SetId(id);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                AddError(Resources.Whatever_Name_invalid);
                return;
            }

            Name = name;
        }

        private void SetTime(DateTime time)
        {
            if (time.Equals(DateTime.MinValue))
            {
                AddError(Resources.Whatever_Time_invalid);
                return;
            }

            Time = time;
        }

        private void SetType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                AddError(Resources.Whatever_Type_invalid);
                return;
            }

            Type = type;
        }
    }
}