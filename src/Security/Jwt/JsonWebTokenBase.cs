using System;
using System.Collections.Generic;
using Bit0.Utils.Common.Extensions;

namespace Bit0.Utils.Security.Jwt
{

    public abstract class JsonWebTokenBase : IJwt
    {
        protected IDictionary<string, object> _claims = new Dictionary<string, object>();
        public abstract IDictionary<string, object> Claims { get; }

        public virtual double Expiry => (double)_claims[JwtClaimKeys.Expiry];
        public virtual double IssuedAt => (double)_claims[JwtClaimKeys.IssuedAt];
        public virtual double NotBefore => (double)_claims[JwtClaimKeys.NotBefore];

        public virtual string Issuer => throw new NotImplementedException($"{nameof(Issuer)} not implemented in Jwt.");
        public virtual string Audience => throw new NotImplementedException($"{nameof(Audience)} not implemented in Jwt.");

        public JsonWebTokenBase(int expiresinSeconds = 1800, int notBeforeSeconds = 0)
        {
            _claims.Add(JwtClaimKeys.Expiry, DateTime.Now.AddSeconds(expiresinSeconds).ToUnixEpoch());
            _claims.Add(JwtClaimKeys.IssuedAt, DateTime.Now.ToUnixEpoch());
            _claims.Add(JwtClaimKeys.NotBefore, DateTime.Now.AddSeconds(notBeforeSeconds).ToUnixEpoch());
        }
    }
}