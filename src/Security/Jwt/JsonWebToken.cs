using System;
using System.Collections.Generic;
using Bit0.Utils.Common.Extensions;

namespace Bit0.Utils.Security.Jwt
{
    /// <summary>
    /// Implementation of Json Web Token
    /// </summary>
    public abstract class JsonWebToken : IJwt
    {
        /// <summary>
        /// List of claims
        /// </summary>
        protected IDictionary<String, Object> ClaimsList = new Dictionary<String, Object>();

        /// <inheritdoc />
        public abstract IDictionary<String, Object> Claims { get; }

        /// <inheritdoc />
        public Double Expiry => (Double)ClaimsList[JwtClaimKeys.Expiry];

        /// <inheritdoc />
        public Double IssuedAt => (Double)ClaimsList[JwtClaimKeys.IssuedAt];

        /// <inheritdoc />
        public Double NotBefore => (Double)ClaimsList[JwtClaimKeys.NotBefore];

        /// <inheritdoc />
        public String Issuer => (String)ClaimsList[JwtClaimKeys.Issuer];

        /// <inheritdoc />
        public String Audience => (String)ClaimsList[JwtClaimKeys.Audience];

        /// <summary>
        /// Implementation of Json Web Token
        /// </summary>
        /// <param name="expiresInSeconds">Token expires after in, in seconds</param>
        /// <param name="notBeforeSeconds">Cannot use token before, in seconds</param>
        protected JsonWebToken(Int32 expiresInSeconds = 1800, Int32 notBeforeSeconds = 0)
        {
            BuildClaims("unknown", "unknown", expiresInSeconds, notBeforeSeconds);
        }

        /// <summary>
        /// Implementation of Json Web Token
        /// </summary>
        /// <param name="issuer">Token Issuer</param>
        /// <param name="audience">Token Audience</param>
        /// <param name="expiresInSeconds">Token expires after in, in seconds</param>
        /// <param name="notBeforeSeconds">Cannot use token before, in seconds</param>
        protected JsonWebToken(String issuer, String audience, Int32 expiresInSeconds = 1800, Int32 notBeforeSeconds = 0)
        {
            BuildClaims(issuer, audience, expiresInSeconds, notBeforeSeconds);
        }

        /// <summary>
        /// Implementation of Json Web Token
        /// </summary>
        /// <param name="claims"></param>
        protected JsonWebToken(IDictionary<String, Object> claims)
        {
            var issuer = (String) claims[JwtClaimKeys.Issuer];
            var audience = (String) claims[JwtClaimKeys.Audience];
            var issuedAt = (Double)claims[JwtClaimKeys.IssuedAt];

            var expireAt = (Double)claims[JwtClaimKeys.Expiry];
            var notBefore = (Double)claims[JwtClaimKeys.NotBefore];

            BuildClaims(issuer, audience, expireAt, notBefore, issuedAt);
        }

        private void BuildClaims(String issuer, String audience, Int32 expiresInSeconds, Int32 notBeforeSeconds)
        {
            var issuedAt = DateTime.Now.ToUnixEpoch();

            var expiresAt = DateTime.Now.AddSeconds(expiresInSeconds).ToUnixEpoch();
            var notBefore = DateTime.Now.AddSeconds(notBeforeSeconds).ToUnixEpoch();

            BuildClaims(issuer, audience, expiresAt, notBefore, issuedAt);
        }

        private void BuildClaims(String issuer, String audience, Double expiresAt, Double notBefore, Double issuedAt)
        {
            ClaimsList.Clear();

            ClaimsList.Add(JwtClaimKeys.Issuer, issuer);
            ClaimsList.Add(JwtClaimKeys.Audience, audience);
            ClaimsList.Add(JwtClaimKeys.IssuedAt, issuedAt);

            ClaimsList.Add(JwtClaimKeys.Expiry, expiresAt);
            ClaimsList.Add(JwtClaimKeys.NotBefore, notBefore);
        }
    }

}