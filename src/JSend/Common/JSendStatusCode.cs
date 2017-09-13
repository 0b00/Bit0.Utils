using System;

namespace Bit0.Utils.JSend.Common
{
    /// <summary>
    /// JSend status codes
    /// </summary>
    public class JSendStatusCode
    {
        /// <summary>
        /// Http status code
        /// </summary>
        public Int32 Code { get; set; }

        /// <summary>
        /// Internal application error code
        /// </summary>
        public Int32 InternalCode { get; set; }

        /// <summary>
        /// JSend status codes
        /// </summary>
        /// <param name="code">Http status code</param>
        public JSendStatusCode(Int32 code = 200)
            : this(code, code)
        { }

        /// <summary>
        /// JSend status codes
        /// </summary>
        /// <param name="code">Http status code</param>
        /// <param name="internalCode">Internal application error code</param>
        public JSendStatusCode(Int32 code, Int32 internalCode)
        {
            Code = code;
            InternalCode = internalCode;
        }
    }
}