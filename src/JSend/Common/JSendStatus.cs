using Bit0.Utils.Attributes;
using Bit0.Utils.JSend.Exceptions;

namespace Bit0.Utils.JSend.Common
{
    /// <summary>
    /// List fof response status for <see cref="JSendException"/>
    /// </summary>
    public enum JSendStatus
    {
        /// <summary>
        /// Success response
        /// </summary>
        [String("success")]
        Success,

        /// <summary>
        /// Error response
        /// </summary>
        [String("error")]
        Error,

        /// <summary>
        /// Fail response
        /// </summary>
        [String("fail")]
        Fail
    }
}
