using System;

namespace Microservice.Whatevers.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}