namespace Bit0.Utils.Security.Jwt
{
    public abstract class JsonWebToken : JsonWebTokenBase
    {
        public override string Issuer => (string)Claims["iss"];
        public override string Subject => (string)Claims["sub"];
        public override string Audience => (string)Claims["aud"];

        public JsonWebToken(int expiresinSeconds = 1800, int notBeforeSeconds = 0)
            : base(expiresinSeconds, notBeforeSeconds)
        { }
    }

}