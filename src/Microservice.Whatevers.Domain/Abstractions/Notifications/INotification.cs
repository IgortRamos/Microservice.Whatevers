using System.Collections.Generic;

namespace Microservice.Whatevers.Domain.Abstractions.Notifications
{
    public interface INotification
    {
        bool IsValid();
        void AddError(string error);
        void AddErrors(params string[] errors);
        string[] GetErrors();
        string GetError();
    }
}