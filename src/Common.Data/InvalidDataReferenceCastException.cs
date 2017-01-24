using System;
using Bit0.Utils.JSend.Exceptions;

namespace Bit0.Utils.Common.Data
{
    /// <summary>
    /// Invalid <see cref="DataReference"/> cast exception
    /// </summary>
    public class InvalidDataReferenceCastException : JSendException
    {
        /// <summary>
        /// Invalid <see cref="DataReference"/> cast exception
        /// </summary>
        /// <param name="id">Original id</param>
        /// <param name="inner">Inner exception</param>
        public InvalidDataReferenceCastException(string id, Exception inner = null)
            : base($"Cannot convert '{id}' to {typeof(DataReference).Name}", 500, inner)
        { }
    }
}
