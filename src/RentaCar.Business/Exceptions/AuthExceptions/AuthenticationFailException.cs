using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Exceptions.AuthExceptions
{
    public sealed class AuthenticationFailException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode => HttpStatusCode.Unauthorized;

        public string errorMessage { get; }

        public AuthenticationFailException()
        {
            errorMessage = "Username/Email or password incorrect";
        }

        public AuthenticationFailException(string message) : base(message)
        {
            errorMessage = message;
        }

        public AuthenticationFailException(string message, Exception? innerException) : base(message, innerException)
        {
            errorMessage = message;
        }
    }
}
