using System;
using Bit0.Utils.JSend.Common;

namespace Bit0.Utils.JSend.Responses
{
    /// <summary>
    /// JSend success response
    /// </summary>
    public class SuccessResponse : SuccessResponse<Object>
    {
        /// <summary>
        /// JSend success response
        /// </summary>
        /// <param name="data">Payload</param>
        /// <param name="code">Http status code</param>
        /// <param name="internalCode">Internal application code</param>
        public SuccessResponse(Object data, Int32 code, Int32 internalCode)
            : base(data, code, internalCode)
        { }


        /// <summary>
        /// JSend success response
        /// </summary>
        /// <param name="data">Payload</param>
        public SuccessResponse(Object data)
            : this(data, 200, 200)
        { }
    }

    /// <summary>
    /// JSend success response
    /// </summary>
    public class SuccessResponse<T> : JSendResponse<T> where T : class
    {
        /// <summary>
        /// JSend success response
        /// </summary>
        /// <param name="data">Payload</param>
        /// <param name="code">Http status code</param>
        /// <param name="internalCode">Internal application code</param>
        public SuccessResponse(T data, Int32 code, Int32 internalCode)
        {
            StatusCode = new JSendStatusCode(code, internalCode);
            Data = data;
        }


        /// <summary>
        /// JSend success response
        /// </summary>
        /// <param name="data">Payload</param>
        public SuccessResponse(T data)
            : this(data, 200, 200)
        { }
    }
}
