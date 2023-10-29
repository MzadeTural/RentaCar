using System.Net;

namespace RentaCar.Business.Exceptions.ReservationExceptions
{
    public class IdCannotConvertException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;

        public string errorMessage { get; }

        public IdCannotConvertException(string message) : base(message)
        {
            errorMessage = message;
        }
    }
}
