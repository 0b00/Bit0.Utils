using System;
using System.Collections.Generic;
using Bit0.Utils.Common.Extensions;
using Jose;

namespace Bit0.Utils.Security.Jwt
{
    /// <summary>
    /// JSON Web Token
    /// </summary>
    public class JwtConvert
    {
        /// <summary>
        /// Creating Tokens
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="secretKey"></param>
        /// <param name="expiresinSeconds"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        public static string Generate(IDictionary<string, object> payload, string secretKey, int? expiresinSeconds = null, JwsAlgorithm algorithm = JwsAlgorithm.HS512)
        {
            //JsonWebToken.JsonSerializer = new JsonNetJWTSerializer();

            if (expiresinSeconds.HasValue)
            {
                payload.Add("exp", DateTime.Now.AddSeconds(expiresinSeconds.Value).ToUnixEpoch());
            }

            payload.Add("iat", DateTime.Now.ToUnixEpoch());
            payload.Add("nbf", DateTime.Now.ToUnixEpoch());

            var token = Jose.JWT.Encode(payload, secretKey, algorithm);
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
            //JsonWebToken.JsonSerializer = new JsonNetJWTSerializer();

            var payload = Jose.JWT.Decode<IDictionary<string, object>>(token, secretKey);
            return payload;
        }

        
    }
}
