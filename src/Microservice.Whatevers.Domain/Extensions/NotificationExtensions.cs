using Microservice.Whatevers.Domain.Abstractions.Notifications;
using Microservice.Whatevers.Domain.Exceptions;

namespace Microservice.Whatevers.Domain.Extensions
{
    public static class NotificationExtensions
    {
        public static T ThrowIfHasErros<T>(this T entity)
            where T : INotification
        {
            if(!entity.IsValid())
                throw new BusinessException(entity.GetError());
            return entity;
        }
    }
}