using System;

namespace Bit0.Utils.Common.Exceptions
{
    /// <summary>
    /// Invalid credentials exception
    /// </summary>
    public class InvalidCredentialsException : ExceptionBase
    {
        /// <summary>
        /// Invalid credentials exception
        /// </summary>
        /// <param name="data">Payload</param>
        /// <param name="inner">Inner exception</param>
        public InvalidCredentialsException(Object data, Exception inner = null)
            : base(data, 403, inner)
        { }
    }
}