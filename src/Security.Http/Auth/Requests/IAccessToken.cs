using System;
using System.Collections.Generic;
using Bit0.Utils.Security.Jwt;

namespace Bit0.Utils.Security.Http.Auth.Requests
{
    /// <inheritdoc />
    /// <summary>
    /// Interface for AccessToken
    /// </summary>
    public interface IAccessToken : IJwt
    {
        /// <summary>
        /// 
        /// </summary>
        String ApplicationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        String DeviceId { get; set; }

        /// <summary>
        /// Rights in <see cref="IAccessToken"/>
        /// </summary>
        IDictionary<String, RoleActionType> Rights { get; set; }
    }
}
