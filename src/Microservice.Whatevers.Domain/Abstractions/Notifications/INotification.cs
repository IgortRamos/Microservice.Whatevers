using System.Collections.Generic;

namespace Microservice.Whatevers.Domain.Abstractions.Notifications
{
    public interface INotification
    {
        bool IsValid();
        void AddError(string error);
        void AddErrors(IEnumerable<string> errors);
        IEnumerable<string> GetErrors();
        string GetError();
    }
}