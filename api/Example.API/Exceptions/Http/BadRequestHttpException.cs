using System;
using System.Net;
using System.Runtime.Serialization;

namespace Example.API.Exceptions.Http
{
    [Serializable]
    public class BadRequestHttpException : HttpException
    {
        #region CONSTANTS

        private const HttpStatusCode ExceptionStatusCode = HttpStatusCode.BadRequest;

        #endregion CONSTANTS

        #region CONSTRUCTORS

        public BadRequestHttpException(string message) : base(ExceptionStatusCode, message)
        {
        }

        public BadRequestHttpException(string message, Exception inner) : base(ExceptionStatusCode, message, inner)
        {
        }

        public BadRequestHttpException() : base(ExceptionStatusCode)
        {
        }

        protected BadRequestHttpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        #endregion CONSTRUCTORS
    }
}
