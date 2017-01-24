using System;

namespace Bit0.Utils.JSend.Exceptions
{
    /// <summary>
    /// Key missing exception
    /// </summary>
    public class KeyMissingException : JSendException
    {
        /// <summary>
        /// Key missing exception
        /// </summary>
        /// <param name="key">Missing key name</param>
        /// <param name="inner">Inner exception</param>
        public KeyMissingException(string key, Exception inner = null)
            : base($"Key not found: {key}", 500, inner)
        { }
    }
}
