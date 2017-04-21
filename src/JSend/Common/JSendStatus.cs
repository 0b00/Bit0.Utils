using Bit0.Utils.Common.Attributes;
using Bit0.Utils.Common.Exceptions;

namespace Bit0.Utils.JSend.Common
{
    /// <summary>
    /// List fof response status for <see cref="ExceptionBase"/>
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
