using System;
using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.Data.Reference;

namespace Bit0.Utils.Data.Exceptions
{
    /// <summary>
    /// Invalid <see cref="DataReference"/> cast exception
    /// </summary>
    public class InvalidDataReferenceCastException : ExceptionBase
    {
        /// <summary>
        /// Invalid <see cref="DataReference"/> cast exception
        /// </summary>
        /// <param name="id">Original id</param>
        /// <param name="inner">Inner exception</param>
        public InvalidDataReferenceCastException(String id, System.Exception inner = null)
            : base($"Cannot convert '{id}' to {typeof(DataReference).Name}", 500, inner)
        { }
    }
}
