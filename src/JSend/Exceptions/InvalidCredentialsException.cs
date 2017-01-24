using System;

namespace Bit0.Utils.JSend.Exceptions
{
    /// <summary>
    /// Invalid credentials exception
    /// </summary>
    public class InvalidCredentialsException : JSendException
    {
        /// <summary>
        /// Invalid credentials exception
        /// </summary>
        /// <param name="data">Payload</param>
        /// <param name="inner">Inner exception</param>
        public InvalidCredentialsException(object data, Exception inner = null) 
            : base(data, 403, inner)
        { }
    }
}