using System;
using System.Collections.Generic;
using JWT;
using JWT.DNX.Json.Net;
using Bit0.Utils.Common.Extensions;

namespace Bit0.Utils.Security.Jwt
{
    /// <summary>
    /// JSON Web Token
    /// </summary>
    public class JwtToken
    {
        /// <summary>
        /// Creating Tokens
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="secretKey"></param>
        /// <param name="expiresinSeconds"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        public static string Generate(IDictionary<string, object> payload, string secretKey, int? expiresinSeconds = null, JwtHashAlgorithm algorithm = JwtHashAlgorithm.HS512)
        {
            JsonWebToken.JsonSerializer = new JsonNetJWTSerializer();

            if (expiresinSeconds.HasValue)
            {
                payload.Add("exp", DateTime.Now.AddSeconds(expiresinSeconds.Value).ToUnixEpoch());
            }

            payload.Add("iat", DateTime.Now.ToUnixEpoch());
            payload.Add("nbf", DateTime.Now.ToUnixEpoch());

            var token = JsonWebToken.Encode(payload, secretKey, algorithm);
            return token;
        }

        /// <summary>
        /// Verifying and Decoding Tokens
        /// </summary>
        /// <param name="token"></param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static IDictionary<string, object> Validate(string token, string secretKey)
        {
            JsonWebToken.JsonSerializer = new JsonNetJWTSerializer();

            var payload = JsonWebToken.DecodeToObject(token, secretKey) as IDictionary<string, object>;
            return payload;
        }

        
    }
}
