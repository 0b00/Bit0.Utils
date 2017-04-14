using System;
using System.Collections.Generic;
using System.Text;

namespace Bit0.Utils.Security.Jwt
{
    /// <summary>
    /// Jwt claim keys
    /// </summary>
    public static class JwtClaimKeys
    {
        /// <summary>
        /// Claim key for audience
        /// </summary>
        public const string Audience = "aud";

        /// <summary>
        /// Claim key for issuer
        /// </summary>
        public const string Issuer = "iss";


        /// <summary>
        /// Claim key for expiry
        /// </summary>
        public const string Expiry = "exp";

        /// <summary>
        /// Claim key for issued at
        /// </summary>
        public const string IssuedAt = "iat";

        /// <summary>
        /// Claim key for not before
        /// </summary>
        public const string NotBefore = "nbf";
    }
}
