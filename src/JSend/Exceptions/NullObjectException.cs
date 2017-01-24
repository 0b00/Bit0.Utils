﻿using System;

namespace Bit0.Utils.JSend.Exceptions
{
    /// <summary>
    /// Null object exception
    /// </summary>
    public class NullObjectException : JSendException
    {
        /// <summary>
        /// Null object exception
        /// </summary>
        /// <param name="obj">Payload</param>
        /// <param name="inner">Inner exception</param>
        public NullObjectException(string obj, Exception inner = null)
            : base($"Null object: {obj}", 500, inner)
        { }
    }
}
