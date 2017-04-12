using System;
using System.Collections.Generic;
using Bit0.Utils.Common.Extensions;
using Bit0.Utils.JSend.Exceptions;

namespace Bit0.Utils.Security.Jwt
{
    public static class JwtWrapper
    {
        public static string Generate(IDictionary<string, object> payload, IJwtKey jwtKey, int? expiresinSeconds = null)
        {
            var token = Jose.JWT.Encode(payload, jwtKey.Key, jwtKey.Algorithm);
            return token;
        }

        public static IDictionary<string, object> Validate(string token, IJwtKey jwtKey)
        {
            var jwt = Jose.JWT.Decode<IDictionary<string, object>>(token, jwtKey.Key);

            if (double.TryParse(jwt["exp"] as string, out double exp))
            {
                throw new InvalidCredentialsException(new { message = "Invalid access token." });
            }

            if (exp.ToUtc() <= DateTime.UtcNow)
            {
                throw new InvalidCredentialsException(new { message = "Access token has expired." });
            }

            return jwt;
        }

        public static IDictionary<string, object> Payload(string token)
        {
            return Jose.JWT.Payload<IDictionary<string, object>>(token);
        }
    }
}
