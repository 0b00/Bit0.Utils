using System;
using Bit0.Utils.Data;
using Bit0.Utils.Data.Http.Attributes;

namespace Bit0.Utils.Auth.Requests
{
    /// <inheritdoc />
    /// <summary>
    /// Device registration request
    /// </summary>
    public interface IDeviceRegister : IMapper<IDevice>
    {
        /// <summary>
        /// Application Id (json: appId). 
        /// <remarks>Use <see cref="DataValidation"/></remarks>
        /// </summary>
        String ApplicationId { get; set; }

        /// <summary>
        /// Platform
        /// </summary>
        String Platform { get; set; }

        /// <summary>
        /// Platfrom version
        /// </summary>
        String PlatformVersion { get; set; }

        /// <summary>
        /// Hardware Id
        /// </summary>
        String HardwareId { get; set; }
    }
}
