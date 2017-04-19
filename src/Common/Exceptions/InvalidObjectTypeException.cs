using System;

namespace Bit0.Utils.Common.Exceptions
{
    /// <summary>
    /// Invalid object type exception
    /// </summary>
    public class InvalidObjectTypeException : ExceptionBase
    {
        /// <summary>
        /// Invalid object type exception
        /// </summary>
        /// <param name="expected">Expected type</param>
        /// <param name="got">Received type</param>
        /// <param name="inner">Inner exception</param>
        public InvalidObjectTypeException(Type expected, Type got, Exception inner = null)
            : base($"Expected type '{expected.FullName}' got '{got.FullName}'.", 500, inner)
        { }
    }
}
