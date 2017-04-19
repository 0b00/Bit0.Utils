using System;
using Bit0.Utils.Common.Exceptions;

namespace Bit0.Utils.Http.Exceptions
{
    /// <summary>
    /// Url Not Found Exception
    /// </summary>
    public class UrlNotFoundException : ExceptionBase
    {
        /// <summary>
        /// Url Not Found Exception
        /// </summary>
        /// <param name="url">Uri not found</param>
        /// <param name="inner">Inner exception</param>
        public UrlNotFoundException(string url, Exception inner = null)
            : base(new { route = url, message = "Page not found" }, 404, inner)
        { }
    }
}
