using System;

namespace Bit0.Utils.Common.Exceptions
{
    /// <summary>
    /// Key missing exception
    /// </summary>
    public class KeyMissingException : ExceptionBase
    {
        /// <summary>
        /// Key missing exception
        /// </summary>
        /// <param name="key">Missing key name</param>
        /// <param name="inner">Inner exception</param>
        public KeyMissingException(string key, Exception inner = null)
            : base($"Key not found: {key}", 500, inner)
        { }


        /// <summary>
        /// Key missing exception
        /// </summary>
        /// <param name="keyType">Missing key type</param>
        /// <param name="key">Missing key name</param>
        /// <param name="inner">Inner exception</param>
        public KeyMissingException(Type keyType, string key, Exception inner = null)
            : base(new
            {
                message = $"{keyType.Name} not found: {key}",
                keyType = keyType.FullName,
                key = key
            }, 404, inner)
        { }
    }
}
