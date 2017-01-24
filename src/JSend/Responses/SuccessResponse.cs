using Bit0.Utils.JSend.Common;

namespace Bit0.Utils.JSend.Responses
{
    /// <summary>
    /// JSend success response
    /// </summary>
    public class SuccessResponse : JSendResponse
    {
        /// <summary>
        /// JSend status
        /// </summary>
        protected override JSendStatus Status => JSendStatus.Success;

        /// <summary>
        /// JSend success response
        /// </summary>
        /// <param name="data">Payload</param>
        public SuccessResponse(object data)
        {
            Data = data;
        }
    }
}
