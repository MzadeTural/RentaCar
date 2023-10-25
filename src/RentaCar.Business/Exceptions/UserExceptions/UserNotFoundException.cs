using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Exceptions.UserExceptions
{
    public class UserNotFoundException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode { get; }

        public string errorMessage { get; }


        public UserNotFoundException(string key, string value)
        {
            HttpStatusCode = HttpStatusCode.Unauthorized;
            errorMessage = $"User not found with {key}: {value}";
        }

        public UserNotFoundException(string message, HttpStatusCode? statusCode = null) : base(message)
        {
            HttpStatusCode = statusCode ?? HttpStatusCode.Unauthorized;
            errorMessage = message;
        }

        public UserNotFoundException(string message, HttpStatusCode statusCode, Exception? innerException) : base(message, innerException)
        {
            HttpStatusCode = statusCode;
            errorMessage = message;
        }
    }
}
