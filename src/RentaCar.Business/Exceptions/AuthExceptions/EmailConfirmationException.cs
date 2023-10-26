using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Exceptions.AuthExceptions
{
    public class EmailConfirmationException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;

        public string errorMessage { get; }
        public string? errorDetail { get; }

        public EmailConfirmationException()
        {
            errorMessage = "Unexpected error occurred while activate user";
        }

        public EmailConfirmationException(IEnumerable<IdentityError> errors)
        {
            errorMessage = "Unexpected error occurred while activate user";
            errorDetail = String.Join(',', errors.Select(e => e.Description));
        }

        public EmailConfirmationException(string message) : base(message)
        {
            errorMessage = message;
        }

        public EmailConfirmationException(string message, Exception? innerException) : base(message, innerException)
        {
            errorMessage = message;
        }


    }
}
