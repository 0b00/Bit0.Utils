using System;
using Bit0.Utils.Data.Http.Attributes;

namespace Bit0.Utils.Auth.Requests
{
    /// <summary>
    /// Login request
    /// </summary>
    public interface ILogin
    {
        /// <summary>
        /// Username
        /// </summary>
        String Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        String Password { get; set; }

        /// <summary>
        /// Device Id.
        /// <remarks>Use <see cref="DataValidation"/></remarks>
        /// </summary>
        String DeviceId { get; set; }
    }
}
