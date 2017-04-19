using System;

namespace Bit0.Utils.Common.Exceptions
{
    /// <summary>
    /// Not Implemented
    /// </summary>
    public class NotImplementedException : ExceptionBase
    {
        /// <summary>
        /// Not Implemented
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="inner">Inner exception</param>
        protected NotImplementedException(string message, Exception inner = null)
            : base(message, 500, inner)
        { }
    }
}
