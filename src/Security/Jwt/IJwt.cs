using System.Collections.Generic;

namespace Bit0.Utils.Security.Jwt
{
    public interface IJwt
    {
        IDictionary<string, object> Claims { get; }

        double Expiry { get; }
        double IssuedAt { get; }
        double NotBefore { get; }

        string Issuer { get; }
        string Subjet { get; }
        string Audience { get; }

    }
}
