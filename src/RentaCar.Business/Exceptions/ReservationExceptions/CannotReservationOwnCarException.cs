using System.Net;

namespace RentaCar.Business.Exceptions.ReservationExceptions
{
    public class CannotReservationOwnCarException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;

        public string errorMessage { get; }

        public CannotReservationOwnCarException(string message) : base(message)
        {
            errorMessage = message;
        }
    }
}
