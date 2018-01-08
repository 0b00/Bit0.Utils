using System;

namespace Bit0.Utils.Security.Http.Auth.Requests
{
    /// <summary>
    /// Refresh token request
    /// </summary>
    public interface IRefresh
    {
        /// <summary>
        /// Refresh Token
        /// </summary>
        String Token { get; set; }
    }
}
