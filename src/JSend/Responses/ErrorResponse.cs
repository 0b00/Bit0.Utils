using System;
using Bit0.Utils.JSend.Common;
using Newtonsoft.Json;

namespace Bit0.Utils.JSend.Responses
{
    /// <summary>
    /// JSend error response
    /// </summary>
    public class ErrorResponse : JSendResponse
    {
        /// <summary>
        /// Exception
        /// </summary>
        [JsonIgnore]
        public Exception Exception { get; }

        /// <summary>
        /// Exception stack
        /// </summary>
        public string StackTrace => Exception.StackTrace;

        /// <summary>
        /// JSend error response
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="code">Http status code</param>
        /// <param name="internalCode">Internal application code</param>
        /// <param name="exception">Exception</param>
        public ErrorResponse(string message, int code, int internalCode, Exception exception)
        {
            Status = JSendStatus.Error;
            StatusCode = new JSendStatusCode(code, internalCode);
            Message = message;
            Exception = exception;
        }

        /// <summary>
        /// JSend error response
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="code">Http status code</param>
        /// <param name="internalCode">Internal application code</param>
        public ErrorResponse(string message, int code, int internalCode)
        {
            Status = JSendStatus.Error;
            StatusCode = new JSendStatusCode(code, internalCode);
            Message = message;
        }

        /// <summary>
        /// JSend error response
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="exception">Exception</param>
        public ErrorResponse(string message, Exception exception)
            : this(message, 500, 500, exception)
        { }

        /// <summary>
        /// JSend error response
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="internalCode">Internal application code</param>
        /// <param name="exception">Exception</param>
        public ErrorResponse(string message, int internalCode, Exception exception)
            : this(message, 500, internalCode, exception)
        { }
    }
}
