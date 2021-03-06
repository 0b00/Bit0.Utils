﻿using System;
using Bit0.Utils.Data;
using Bit0.Utils.Data.Http.Attributes;

namespace Bit0.Utils.Security.Http.Auth
{
    /// <inheritdoc />
    /// <summary>
    /// Device interface
    /// </summary>
    public interface IDevice : IData
    {
        /// <summary>
        /// Application Id.
        /// <remarks>Use <see cref="DataValidation"/></remarks>
        /// </summary>
        String ApplicationId { get; set; }

        /// <summary>
        /// Platform (Android, iOS, etc)
        /// </summary>
        String Platform { get; set; }

        /// <summary>
        /// Platform version (7.0.1, 8.0.0, etc)
        /// </summary>
        String PlatformVersion { get; set; }

        /// <summary>
        /// Hardware Id
        /// </summary>
        String HardwareId { get; set; }
    }
}
