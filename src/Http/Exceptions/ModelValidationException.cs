using Bit0.Utils.Common.Exceptions;

namespace Bit0.Utils.Http.Exceptions
{
    /// <summary>
    /// Model Validation Exception
    /// </summary>
    public class ModelValidationException : ExceptionBase
    {
        /// <summary>
        /// Model Validation Exception
        /// </summary>
        /// <param name="data">Payload</param>
        public ModelValidationException(object data)
            : base(data, 400, 400)
        { }
    }
}
