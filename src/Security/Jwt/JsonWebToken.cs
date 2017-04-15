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
        protected IDictionary<string, object> ClaimsList = new Dictionary<string, object>();

        /// <inheritdoc />
        public abstract IDictionary<string, object> Claims { get; }

        /// <inheritdoc />
        public double Expiry => (double)ClaimsList[JwtClaimKeys.Expiry];

        /// <inheritdoc />
        public double IssuedAt => (double)ClaimsList[JwtClaimKeys.IssuedAt];

        /// <inheritdoc />
        public double NotBefore => (double)ClaimsList[JwtClaimKeys.NotBefore];

        /// <inheritdoc />
        public string Issuer => (string)ClaimsList[JwtClaimKeys.Issuer];

        /// <inheritdoc />
        public string Audience => (string)ClaimsList[JwtClaimKeys.Audience];

        /// <summary>
        /// Implementation of Json Web Token
        /// </summary>
        /// <param name="expiresinSeconds">Token expires after in, in seconds</param>
        /// <param name="notBeforeSeconds">Cannot use token before, in seconds</param>
        protected JsonWebToken(int expiresinSeconds = 1800, int notBeforeSeconds = 0)
        {
            BuildClaims("unknown", "unknown", expiresinSeconds, notBeforeSeconds);
        }

        /// <summary>
        /// Implementation of Json Web Token
        /// </summary>
        /// <param name="issuer">Token Issuer</param>
        /// <param name="audience">Token Audience</param>
        /// <param name="expiresinSeconds">Token expires after in, in seconds</param>
        /// <param name="notBeforeSeconds">Cannot use token before, in seconds</param>
        protected JsonWebToken(string issuer, string audience, int expiresinSeconds = 1800, int notBeforeSeconds = 0)
        {
            BuildClaims(issuer, audience, expiresinSeconds, notBeforeSeconds);
        }

        /// <summary>
        /// Implementation of Json Web Token
        /// </summary>
        /// <param name="claims"></param>
        protected JsonWebToken(IDictionary<string, object> claims)
        {
            var issuer = (string) claims[JwtClaimKeys.Issuer];
            var audience = (string) claims[JwtClaimKeys.Audience];
            var issuedAt = (double)claims[JwtClaimKeys.IssuedAt];

            var expireAt = (double)claims[JwtClaimKeys.Expiry];
            var notBefore = (double)claims[JwtClaimKeys.NotBefore];

            BuildClaims(issuer, audience, expireAt, notBefore, issuedAt);
        }

        private void BuildClaims(string issuer, string audience, int expiresinSeconds, int notBeforeSeconds)
        {
            var issuedAt = DateTime.Now.ToUnixEpoch();

            var expiresAt = DateTime.Now.AddSeconds(expiresinSeconds).ToUnixEpoch();
            var notBefore = DateTime.Now.AddSeconds(notBeforeSeconds).ToUnixEpoch();

            BuildClaims(issuer, audience, expiresAt, notBefore, issuedAt);
        }

        private void BuildClaims(string issuer, string audience, double expiresAt, double notBefore, double issuedAt)
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