using System;

namespace Bit0.Utils.Common.Exceptions
{
    /// <summary>
    /// Argument missing exception
    /// </summary>
    public class ArgumentMissingException : ExceptionBase
    {
        /// <summary>
        /// Argument missing exceptions
        /// </summary>
        /// <param name="arg">Missing argument</param>
        /// <param name="inner">Inner exception</param>
        public ArgumentMissingException(String arg, Exception inner = null)
            : base($"Missing argument: {arg}", 500, inner)
        { }
    }
}
