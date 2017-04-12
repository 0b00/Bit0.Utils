namespace Bit0.Utils.Security.Jwt
{
    public abstract class JsonWebToken : JsonWebTokenBase
    {
        public override string Issuer => (string)_claims[JwtClaimKeys.Issuers];
        public override string Audience => (string)_claims[JwtClaimKeys.Audience];

        public JsonWebToken(int expiresinSeconds = 1800, int notBeforeSeconds = 0)
            : base(expiresinSeconds, notBeforeSeconds)
        { }
    }

}