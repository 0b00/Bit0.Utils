using Bit0.Utils.JSend.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bit0.Utils.Common.Data
{
    /// <summary>
    /// Invalid <see cref="IData"/> cast exception
    /// </summary>
    public class InvalidDataCastException : JSendException
    {
        /// <summary>
        /// Invalid <see cref="IData"/> cast exception
        /// </summary>
        /// <param name="id">Original id</param>
        /// <param name="inner">Inner exception</param>
        public InvalidDataCastException(string id, Exception inner = null)
            : base($"Cannot convert '{id}' to {typeof(IData).Name}", 500, inner)
        { }
    }
}
