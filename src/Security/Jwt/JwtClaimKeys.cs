using System;

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
        public const String Audience = "aud";

        /// <summary>
        /// Claim key for issuer
        /// </summary>
        public const String Issuer = "iss";


        /// <summary>
        /// Claim key for expiry
        /// </summary>
        public const String Expiry = "exp";

        /// <summary>
        /// Claim key for issued at
        /// </summary>
        public const String IssuedAt = "iat";

        /// <summary>
        /// Claim key for not before
        /// </summary>
        public const String NotBefore = "nbf";
    }
}
