namespace Bit0.Utils.Security.Jwt
{
    public abstract class JsonWebToken : JsonWebTokenBase
    {
        public override string Issuer => (string)Claims[JwtClaimKeys.Issuers];
        public override string Subject => (string)Claims[JwtClaimKeys.Subject];
        public override string Audience => (string)Claims[JwtClaimKeys.Audience];

        public JsonWebToken(int expiresinSeconds = 1800, int notBeforeSeconds = 0)
            : base(expiresinSeconds, notBeforeSeconds)
        { }
    }

}