using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Exceptions.AuthExceptions.Token
{
    public class RefreshTokenExpiredException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode => HttpStatusCode.Unauthorized;

        public string errorMessage { get; }

        public RefreshTokenExpiredException()
        {
            errorMessage = "Refresh Token Expired";
        }

        public RefreshTokenExpiredException(string message) : base(message)
        {
            errorMessage = message;
        }

        public RefreshTokenExpiredException(string message, Exception? innerException) : base(message, innerException)
        {
            errorMessage = message;
        }
    }
}
