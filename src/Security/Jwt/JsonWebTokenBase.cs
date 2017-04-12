using System;
using System.Collections.Generic;
using Bit0.Utils.Common.Extensions;

namespace Bit0.Utils.Security.Jwt
{

    public abstract class JsonWebTokenBase : IJwt
    {
        public abstract IDictionary<string, object> Claims { get; }

        public virtual double Expiry => (double)Claims["exp"];
        public virtual double IssuedAt => (double)Claims["iat"];
        public virtual double NotBefore => (double)Claims["nbf"];

        public virtual string Issuer => throw new NotImplementedException($"{nameof(Issuer)} not implemented in Jwt.");
        public virtual string Subject => throw new NotImplementedException($"{nameof(Subject)} not implemented in Jwt.");
        public virtual string Audience => throw new NotImplementedException($"{nameof(Audience)} not implemented in Jwt.");

        public JsonWebTokenBase(int expiresinSeconds = 1800, int notBeforeSeconds = 0)
        {
            Claims.Add("exp", DateTime.Now.AddSeconds(expiresinSeconds).ToUnixEpoch());
            Claims.Add("iat", DateTime.Now.ToUnixEpoch());
            Claims.Add("nbf", DateTime.Now.AddSeconds(notBeforeSeconds).ToUnixEpoch());
        }
    }
}