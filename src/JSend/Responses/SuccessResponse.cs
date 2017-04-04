using Bit0.Utils.JSend.Common;

namespace Bit0.Utils.JSend.Responses
{
    /// <summary>
    /// JSend success response
    /// </summary>
    public class SuccessResponse : JSendResponse
    {
        /// <summary>
        /// JSend success response
        /// </summary>
        /// <param name="data">Payload</param>
        /// <param name="code">Http status code</param>
        /// <param name="internalCode">Internal application code</param>
        public SuccessResponse(object data, int code, int internalCode)
        {
            StatusCode = new JSendStatusCode(code, internalCode);
            Data = data;
        }


        /// <summary>
        /// JSend success response
        /// </summary>
        /// <param name="data">Payload</param>
        public SuccessResponse(object data)
            : this(data, 200, 200)
        { }
    }
}
