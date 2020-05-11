using System.Collections.Generic;
using System.Linq;

namespace Microservice.Whatevers.Domain.Abstractions.Notifications
{
    public abstract class Notification :  INotification
    {
        private readonly IList<string> _errors = new List<string>();

        public bool IsValid() => !_errors.Any();

        public void AddError(string error)
        {
            _errors.Add(error);
        }

        public void AddErrors(params string[] errors)
        {
            if (errors != null && _errors is List<string> errorsCast)
                errorsCast.AddRange(errors);
        }

        public string[] GetErrors() => _errors.ToArray();
        
        public string GetError() => string.Join("; ", _errors);
    }
}