using System;
using System.Collections.Generic;
using System.Text;

namespace Bit0.Utils.Security.Jwt
{
    public static class JwtClaimKeys
    {
        public const string Audience = "aud";
        public const string Issuers = "iss";

        public const string Expiry = "exp";
        public const string IssuedAt = "iat";
        public const string NotBefore = "nbf";
    }
}
