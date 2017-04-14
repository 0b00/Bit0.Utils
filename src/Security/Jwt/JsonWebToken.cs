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
        /// <inheritdoc />
        public IDictionary<string, object> Claims { get; } = new Dictionary<string, object>();

        /// <inheritdoc />
        public double Expiry => (double)Claims[JwtClaimKeys.Expiry];

        /// <inheritdoc />
        public double IssuedAt => (double)Claims[JwtClaimKeys.IssuedAt];

        /// <inheritdoc />
        public double NotBefore => (double)Claims[JwtClaimKeys.NotBefore];

        /// <inheritdoc />
        public string Issuer => (string)Claims[JwtClaimKeys.Issuer];

        /// <inheritdoc />
        public string Audience => (string)Claims[JwtClaimKeys.Audience];

        /// <summary>
        /// Implementation of Json Web Token
        /// </summary>
        /// <param name="expiresinSeconds">Token expires after in, in seconds</param>
        /// <param name="notBeforeSeconds">Cannot use token before, in seconds</param>
        protected JsonWebToken(int expiresinSeconds = 1800, int notBeforeSeconds = 0)
        {
            if (!Claims.ContainsKey(JwtClaimKeys.Expiry))
                Claims.Add(JwtClaimKeys.Expiry, DateTime.Now.AddSeconds(expiresinSeconds).ToUnixEpoch());
            if (!Claims.ContainsKey(JwtClaimKeys.IssuedAt))
                Claims.Add(JwtClaimKeys.IssuedAt, DateTime.Now.ToUnixEpoch());
            if (!Claims.ContainsKey(JwtClaimKeys.NotBefore))
                Claims.Add(JwtClaimKeys.NotBefore, DateTime.Now.AddSeconds(notBeforeSeconds).ToUnixEpoch());
        }
    }

}