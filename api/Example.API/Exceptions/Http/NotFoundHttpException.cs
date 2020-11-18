using System;
using System.Net;
using System.Runtime.Serialization;

namespace Example.API.Exceptions.Http
{
    [Serializable]
    public class NotFoundHttpException : HttpException
    {
        #region CONSTANTS

        private const HttpStatusCode ExceptionStatusCode = HttpStatusCode.NotFound;

        #endregion CONSTANTS

        #region CONSTRUCTORS

        public NotFoundHttpException(string message) : base(ExceptionStatusCode, message)
        {
        }

        public NotFoundHttpException(string message, Exception inner) : base(ExceptionStatusCode, message, inner)
        {
        }

        public NotFoundHttpException() : base(ExceptionStatusCode)
        {
        }

        protected NotFoundHttpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        #endregion CONSTRUCTORS
    }
}
