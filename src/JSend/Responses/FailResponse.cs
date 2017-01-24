using Bit0.Utils.JSend.Common;

namespace Bit0.Utils.JSend.Responses
{
    /// <summary>
    /// JSend fail response
    /// </summary>
    public class FailResponse : JSendResponse
    {
        /// <summary>
        /// JSend status
        /// </summary>
        protected override JSendStatus Status => JSendStatus.Fail;

        /// <summary>
        /// JSend fail response
        /// </summary>
        /// <param name="data">Payload</param>
        public FailResponse(object data)
        {
            Data = data;
        }
    }
}
