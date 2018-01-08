using System;
using Bit0.Utils.Data;

namespace Bit0.Utils.JSend.Http
{
    /// <summary>
    /// Interface for JSend controller
    /// </summary>
    public interface IJSendController
    {
        /// <summary>
        /// <see cref="IData"/> type for controller
        /// </summary>
        Type DataType { get; }
    }
}
