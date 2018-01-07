using System;

namespace Bit0.Utils.Security.Jwt
{
    /// <summary>
    /// Jwt claim keys
    /// </summary>
    public static class JwtClaimKeys
    {
        /// <summary>
        /// JWT audience
        /// </summary>
        public const String Audience = "aud";

        /// <summary>
        /// JWT issuer
        /// </summary>
        public const String Issuer = "iss";


        /// <summary>
        /// JWT expires at
        /// </summary>
        public const String Expiry = "exp";

        /// <summary>
        /// JWT issued at
        /// </summary>
        public const String IssuedAt = "iat";

        /// <summary>
        /// Cannot use JWT before
        /// </summary>
        public const String NotBefore = "nbf";

        /// <summary>
        /// JWT subject (i.e. user)
        /// </summary>
        public const String Subject = "sub";

        /// <summary>
        /// JWT scope (i.e. rights)
        /// </summary>
        public const String Scope = "scp";
    }
}
