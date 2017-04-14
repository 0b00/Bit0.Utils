using System.Collections.Generic;

namespace Bit0.Utils.Security.Jwt
{
    /// <summary>
    /// Interface for Json Web Token
    /// </summary>
    public interface IJwt
    {
        /// <summary>
        /// All claims
        /// </summary>
        IDictionary<string, object> Claims { get; }

        /// <summary>
        /// Expiry claim
        /// </summary>
        double Expiry { get; }

        /// <summary>
        /// Issued at claim
        /// </summary>
        double IssuedAt { get; }

        /// <summary>
        /// Not before claim
        /// </summary>
        double NotBefore { get; }

        /// <summary>
        /// Issuer claim
        /// </summary>
        string Issuer { get; }

        /// <summary>
        /// Audience claim
        /// </summary>
        string Audience { get; }

    }
}
