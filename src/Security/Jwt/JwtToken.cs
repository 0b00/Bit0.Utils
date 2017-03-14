using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Bit0.Utils.Security.Jwt
{
    /// <summary>
    /// JSON Web Token
    /// </summary>
    public class JwtToken
    {
        /// <summary>
        /// Generate new token
        /// </summary>
        /// <param name="claimsIdentity">Claims in the token</param>
        /// <param name="signingKey">Key</param>
        /// <returns></returns>
        public static string Generate(ClaimsIdentity claimsIdentity, SecurityKey signingKey)
        {
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

            return signedAndEncodedToken;
        }

        /// <summary>
        /// Validate a JWT token
        /// </summary>
        /// <param name="signedAndEncodedToken">TOken</param>
        /// <param name="signingKey">Key</param>
        /// <returns></returns>
        public SecurityToken Validate(string signedAndEncodedToken, SecurityKey signingKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenValidationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = signingKey
            };

            SecurityToken validatedToken;
            tokenHandler.ValidateToken(signedAndEncodedToken, tokenValidationParameters, out validatedToken);

            return validatedToken;
        }
    }
}
