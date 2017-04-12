using System.Collections.Generic;

namespace Bit0.Utils.Security.Jwt
{
    public abstract class JsonWebToken : IJwt
    {
        public abstract IDictionary<string, object> Claims { get; }

        public double Expiry => (double)Claims["exp"];
        public double IssuedAt => (double)Claims["iat"];
        public double NotBefore => (double)Claims["nbf"];

        public string Issuer => (string)Claims["iss"];
        public string Subject => (string)Claims["sub"];
        public string Audience => (string)Claims["aud"];

    }
}