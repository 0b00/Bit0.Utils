using System;

namespace Bit0.Utils.Common.Exceptions
{
    /// <summary>
    /// Exception base
    /// </summary>
    public abstract class ExceptionBase : Exception
    {
        /// <summary>
        /// Status code
        /// </summary>
        public int StatusCode { get; }
        /// <summary>
        /// Exception payload
        /// </summary>
        public ExceptionResponse ResponseObject { get; }

        /// <summary>
        /// Exception base for Fail
        /// </summary>
        /// <param name="data">Fail data</param>
        /// <param name="status">Fail status</param>
        /// <param name="inner">Inner exception</param>
        protected ExceptionBase(object data, int status = 400, Exception inner = null)
            : this(data, status, status, inner)
        { }

        /// <summary>
        /// Exception base for Fail
        /// </summary>
        /// <param name="data">Fail data</param>
        /// <param name="status">Fail status</param>
        /// <param name="innerStatus">Inner status</param>
        /// <param name="inner">Inner exception</param>
        protected ExceptionBase(object data, int status = 400, int innerStatus = 400, Exception inner = null)
            : base("Fail", inner)
        {
            StatusCode = status;
            ResponseObject = new ExceptionResponse(data, status, innerStatus, inner);
        }

        /// <summary>
        /// Exception base for Error
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="status">Error status</param>
        /// <param name="inner">Inner exception</param>
        protected ExceptionBase(string message, int status = 500, Exception inner = null)
            : this(message, status, status, inner)
        { }

        /// <summary>
        /// Exception base for Error
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="status">Error status</param>
        /// <param name="innerStatus">Inner status</param>
        /// <param name="inner">Inner exception</param>
        protected ExceptionBase(string message, int status = 500, int innerStatus = 500, Exception inner = null)
            : base($"Error: {message}", inner)
        {
            StatusCode = status;
            ResponseObject = new ExceptionResponse(message, status, innerStatus, inner);
        }
    }
}
