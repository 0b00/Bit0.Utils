using Bit0.Utils.Data;
using System;

namespace Bit0.Utils.Http.Controllers
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
