using System;
using Bit0.Utils.Data;
using Bit0.Utils.Data.Http.Attributes;

namespace Bit0.Utils.Security.Http
{
    /// <inheritdoc />
    /// <summary>
    /// Device interface
    /// </summary>
    public interface IDevice : IData
    {
        /// <summary>
        /// Aplication Id.
        /// <remarks>Use <see cref="DataValidation"/></remarks>
        /// </summary>
        String ApplcationId { get; set; }

        /// <summary>
        /// Platform (Android, iOS, etc)
        /// </summary>
        String Platform { get; set; }

        /// <summary>
        /// Platform version (7.0.1, 8.0.0, etc)
        /// </summary>
        String PlatformVersion { get; set; }

        /// <summary>
        /// Harsware Id
        /// </summary>
        String HardwareId { get; set; }
    }
}
