using System;
using Bit0.Utils.JSend.Responses;

namespace Bit0.Utils.JSend.Exceptions
{
    /// <summary>
    /// JSend exception base
    /// </summary>
    public abstract class JSendException : Exception
    {
        /// <summary>
        /// HTTP status code
        /// </summary>
        public int StatusCode { get; }
        /// <summary>
        /// Exception payload
        /// </summary>
        public JSendResponse ResponseObject { get; }

        /// <summary>
        /// JSend exception
        /// </summary>
        /// <param name="data">Payload</param>
        /// <param name="status">Http status</param>
        /// <param name="inner">Inner exception</param>
        protected JSendException(object data, int status = 400, Exception inner = null) : base("JSONFail", inner)
        {
            StatusCode = status;
            ResponseObject = new FailResponse(data, status, status);
        }

        /// <summary>
        /// JSend exception
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="status">Http status</param>
        /// <param name="inner">Inner exception</param>
        protected JSendException(string message, int status = 500, Exception inner = null) : base($"JSONError: {message}", inner)
        {
            StatusCode = status;
            ResponseObject = new ErrorResponse(message, status, status);
        }
    }
}
