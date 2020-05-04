using Microservice.Whatevers.Domain.Abstractions.Notifications;

namespace Microservice.Whatevers.Domain.Abstractions
{
    public abstract class EntityBase<TId> : Notification
        where TId : struct
    {
        public TId Id { get; protected set; }

        protected virtual void SetId(TId id)
        {
            Id = id;
        }
    }
}