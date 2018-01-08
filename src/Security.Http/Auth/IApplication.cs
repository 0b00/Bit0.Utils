using System;
using Bit0.Utils.Data;

namespace Bit0.Utils.Security.Http.Auth
{
    /// <inheritdoc />
    /// <summary>
    /// Application interface
    /// </summary>
    public interface IApplication : IData
    {
        /// <summary>
        /// Application name
        /// </summary>
        String Name { get; set; }

        /// <summary>
        /// Application platform type
        /// </summary>
        ApplicationPlatformType Platform { get; set; }

        /// <summary>
        /// Application version
        /// </summary>
        String Version { get; set; }

        /// <summary>
        /// Application url
        /// </summary>
        String Url { get; set; }
    }
}
