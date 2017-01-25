using Bit0.Utils.JSend.Common;

namespace Bit0.Utils.JSend.Responses
{
    /// <summary>
    /// JSend fail response
    /// </summary>
    public class FailResponse : JSendResponse
    {
        /// <summary>
        /// JSend fail response
        /// </summary>
        /// <param name="data">Payload</param>
        /// <param name="code">Http status code</param>
        /// <param name="internalCode">Internal application code</param>
        public FailResponse(object data, int code = 400, int internalCode = 400)
        {
            Status = JSendStatus.Fail;
            StatusCode = new JSendStatusCode(code, internalCode);
            Data = data;
        }
    }
}
