using System;
using System.Collections.Generic;
using System.Text;

namespace Bit0.Utils.JSend.Exceptions
{
    /// <summary>
    /// Not Implemented
    /// </summary>
    public class JsendNotImplemented : JSendException
    {
        /// <summary>
        /// Not Implemented
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="inner">Inner exception</param>
        protected JsendNotImplemented(string message, Exception inner = null) 
            : base(message, 500, inner)
        { }
    }
}
