using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Exceptions.AuthExceptions
{
    public class AuthorizationException : Exception, IBaseException
    {
      

        public HttpStatusCode HttpStatusCode { get; }

        public string errorMessage { get; }

        public AuthorizationException(string action)
        {
            HttpStatusCode = HttpStatusCode.Forbidden;
            errorMessage = $"You are not authorized to perform this action: {action}";
        }

        public AuthorizationException(string message, HttpStatusCode statusCode) : base(message)
        {
            HttpStatusCode = statusCode;
            errorMessage = message;
        }

        public AuthorizationException(string message, HttpStatusCode statusCode, Exception? innerException) : base(message, innerException)
        {
            HttpStatusCode = statusCode;
            errorMessage = message;
        }
    }
}
