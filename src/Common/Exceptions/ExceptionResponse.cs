using System;
using System.Collections.Generic;

namespace Bit0.Utils.Common.Exceptions
{
    /// <summary>
    /// Exception response
    /// </summary>
    public class ExceptionResponse
    {

        /// <summary>
        /// Exception status
        /// </summary>
        public Int32 StatusCode { get; }

        /// <summary>
        /// Inner status
        /// </summary>
        public Int32 InnerStatus { get; }

        /// <summary>
        /// Exception message
        /// </summary>
        public String Message { get; }

        /// <summary>
        /// Exception data
        /// </summary>
        public Object Data { get; }

        /// <summary>
        /// Inner Exception
        /// </summary>
        public Exception InnerException { get; }

        /// <summary>
        /// Error response
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="status">Error status</param>
        /// <param name="innerStatus">Inner status</param>
        /// <param name="inner">Inner Exception</param>
        public ExceptionResponse(String message, Int32 status = 500, Int32 innerStatus = 500, Exception inner = null)
            : this(status, innerStatus, inner)
        {
            Message = message;
        }

        /// <summary>
        /// Fail response
        /// </summary>
        /// <param name="data">Fail data</param>
        /// <param name="status">Fail status</param>
        /// <param name="innerStatus">Inner status</param>
        /// <param name="inner">Inner Exception</param>
        public ExceptionResponse(Object data, Int32 status = 500, Int32 innerStatus = 500, Exception inner = null)
            : this(status, innerStatus, inner)
        {
            Data = data;
        }

        private ExceptionResponse(Int32 status, Int32 innerStatus, Exception inner)
        {
            StatusCode = status;
            InnerStatus = innerStatus;
            InnerException = inner;

            //if (inner != null)
            //{
            //    StackTrace = inner.StackTrace.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            //}
        }
    }
}