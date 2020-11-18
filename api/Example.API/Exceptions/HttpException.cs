using System;
using System.Net;
using System.Runtime.Serialization;

namespace Example.API.Exceptions
{
    [Serializable]
    public class HttpException : Exception
    {
        #region PROPERTIES

        public HttpStatusCode StatusCode { get; }

        #endregion PROPERTIES

        #region CONSTRUCTORS

        public HttpException(HttpStatusCode code)
        {
            StatusCode = code;
        }

        public HttpException(HttpStatusCode code, string message) : base(message)
        {
            StatusCode = code;
        }

        public HttpException(HttpStatusCode code, string message, Exception inner) : base(message, inner)
        {
            StatusCode = code;
        }

        public HttpException(string message) : base(message)
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public HttpException(string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        protected HttpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        protected HttpException()
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        #endregion CONSTRUCTORS
    }
}
