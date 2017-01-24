using Bit0.Utils.JSend.Common;

namespace Bit0.Utils.JSend.Responses
{
    /// <summary>
    /// JSend error response
    /// </summary>
    public class ErrorResponse : JSendResponse
    {
        /// <summary>
        /// JSend status
        /// </summary>
        protected override JSendStatus Status => JSendStatus.Error;

        /// <summary>
        /// JSend error response
        /// </summary>
        /// <param name="message">Error message</param>
        public ErrorResponse(string message)
        {
            Message = message;
        }
    }
}
