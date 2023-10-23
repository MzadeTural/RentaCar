using System.Net;

namespace RentaCar.Business.Exceptions
{
    public interface IBaseException
    {
        HttpStatusCode HttpStatusCode { get; }
        string errorMessage { get; }
        virtual string? ErrorDetail { get => "Not any error detail"; }

    }
}
