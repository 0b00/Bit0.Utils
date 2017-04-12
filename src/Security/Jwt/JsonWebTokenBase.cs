using System;
using System.Collections.Generic;
using Bit0.Utils.Common.Extensions;

namespace Bit0.Utils.Security.Jwt
{

    public abstract class JsonWebTokenBase : IJwt
    {
        public abstract IDictionary<string, object> Claims { get; }

        public virtual double Expiry => (double)Claims[JwtClaimKeys.Expiry];
        public virtual double IssuedAt => (double)Claims[JwtClaimKeys.IssuedAt];
        public virtual double NotBefore => (double)Claims[JwtClaimKeys.NotBefore];

        public virtual string Issuer => throw new NotImplementedException($"{nameof(Issuer)} not implemented in Jwt.");
        public virtual string Audience => throw new NotImplementedException($"{nameof(Audience)} not implemented in Jwt.");

        public JsonWebTokenBase(int expiresinSeconds = 1800, int notBeforeSeconds = 0)
        {
            Claims.Add(JwtClaimKeys.Expiry, DateTime.Now.AddSeconds(expiresinSeconds).ToUnixEpoch());
            Claims.Add(JwtClaimKeys.IssuedAt, DateTime.Now.ToUnixEpoch());
            Claims.Add(JwtClaimKeys.NotBefore, DateTime.Now.AddSeconds(notBeforeSeconds).ToUnixEpoch());
        }
    }
}