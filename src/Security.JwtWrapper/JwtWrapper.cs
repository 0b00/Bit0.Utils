﻿using System.Collections.Generic;

namespace Bit0.Utils.Security.Jwt
{
    /// <summary>
    /// Json Web Token wrapper
    /// </summary>
    public static class JwtWrapper
    {
        /// <summary>
        /// Genarate a new Json Web Token
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="jwtKey"></param>
        /// <returns></returns>
        public static string Generate(IDictionary<string, object> payload, IJwtKey jwtKey)
        {
            var token = Jose.JWT.Encode(payload, jwtKey.Key, jwtKey.Algorithm);
            return token;
        }

        /// <summary>
        /// Validate a Json Web Token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="jwtKey"></param>
        /// <returns></returns>
        public static IDictionary<string, object> Validate(string token, IJwtKey jwtKey)
        {
            var jwt = Jose.JWT.Decode<IDictionary<string, object>>(token, jwtKey.Key);
            jwt.ValidateDate(JwtClaimKeys.Expiry, "Access token has expired.");
            jwt.ValidateDate(JwtClaimKeys.IssuedAt, "Invalid access token.");
            jwt.ValidateDate(JwtClaimKeys.NotBefore, "Invalid access token, cannot use before {0}.");

            return jwt;
        }
        
        /// <summary>
        /// Get only payload from Json Web Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static IDictionary<string, object> Payload(string token)
        {
            return Jose.JWT.Payload<IDictionary<string, object>>(token);
        }

    }
}