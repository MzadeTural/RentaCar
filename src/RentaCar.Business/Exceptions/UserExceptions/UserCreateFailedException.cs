using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Exceptions.UserExceptions
{
    public sealed class UserCreateFailedException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;

       
        public string? ErrorDetail { get; }

        public string errorMessage { get; }

        public UserCreateFailedException()
        {
            errorMessage = "Unexpected error occurred while creating user";
        }

        public UserCreateFailedException(IEnumerable<IdentityError> errors)
        {
            errorMessage = "Unexpected errors occurred while creating user";
            errorMessage = String.Join(',', errors.Select(e => e.Description));
        }

        public UserCreateFailedException(string message) : base(message)
        {
            errorMessage = message;
        }

        public UserCreateFailedException(string message, Exception? innerException) : base(message, innerException)
        {
            errorMessage = message;
        }
    }
}
