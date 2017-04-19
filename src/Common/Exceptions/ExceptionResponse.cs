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
        public int Status { get; }

        /// <summary>
        /// Inner status
        /// </summary>
        public int InnerStatus { get; }

        /// <summary>
        /// Exception message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Exception data
        /// </summary>
        public object Data { get; }

        /// <summary>
        /// Inner Exception
        /// </summary>
        public IEnumerable<string> StackTrace { get; }

        /// <summary>
        /// Error response
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="status">Error status</param>
        /// <param name="innerStatus">Inner status</param>
        /// <param name="inner">Inner Exception</param>
        public ExceptionResponse(string message, int status = 500, int innerStatus = 500, Exception inner = null)
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
        public ExceptionResponse(object data, int status = 500, int innerStatus = 500, Exception inner = null)
            : this(status, innerStatus, inner)
        {
            Data = data;
        }

        private ExceptionResponse(int status, int innerStatus, Exception inner)
        {
            Status = status;
            InnerStatus = innerStatus;

            if (inner != null)
            {
                StackTrace = inner.StackTrace.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}