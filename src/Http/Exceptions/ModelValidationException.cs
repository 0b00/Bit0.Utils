using Bit0.Utils.JSend.Exceptions;

namespace Bit0.Utils.Http.Exceptions
{
    /// <summary>
    /// Model Validation Exception
    /// </summary>
    public class ModelValidationException : JSendException
    {
        /// <summary>
        /// Model Validation Exception
        /// </summary>
        /// <param name="data">Payload</param>
        public ModelValidationException(object data)
            : base(data)
        { }
    }
}
