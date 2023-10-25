using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Exceptions.AuthExceptions
{
    public class EmailNotConfirmedException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode { get; }

        public string errorMessage { get; }
        public string? ErrorDetail { get; }

        public EmailNotConfirmedException()
        {
            HttpStatusCode = HttpStatusCode.Forbidden;
            errorMessage = "Your account not activated.";
            ErrorDetail = "Please activate your account from email sent link.";
        }

        public EmailNotConfirmedException(string message, HttpStatusCode statusCode) : base(message)
        {
            HttpStatusCode = statusCode;
            errorMessage = message;
        }

        public EmailNotConfirmedException(string message, HttpStatusCode statusCode, Exception? innerException) : base(message, innerException)
        {
            HttpStatusCode = statusCode;
            errorMessage = message;
        }
    }
}
