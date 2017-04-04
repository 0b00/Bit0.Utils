using Bit0.Utils.JSend.Common;

namespace Bit0.Utils.JSend.Responses
{
    /// <summary>
    /// JSend error response
    /// </summary>
    public class ErrorResponse : JSendResponse
    {
        /// <summary>
        /// JSend error response
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="code">Http status code</param>
        /// <param name="internalCode">Internal application code</param>
        public ErrorResponse(string message, int code, int internalCode)
        {
            Status = JSendStatus.Error;
            StatusCode = new JSendStatusCode(code, internalCode);
            Message = message;
        }

        /// <summary>
        /// JSend error response
        /// </summary>
        /// <param name="message">Error message</param>
        public ErrorResponse(string message)
            : this(message, 500, 500)
        { }
    }
}
