using System;
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
        IDictionary<String, Object> Claims { get; }

        /// <summary>
        /// Expiry claim
        /// </summary>
        Double Expiry { get; }

        /// <summary>
        /// Issued at claim
        /// </summary>
        Double IssuedAt { get; }

        /// <summary>
        /// Not before claim
        /// </summary>
        Double NotBefore { get; }

        /// <summary>
        /// Issuer claim
        /// </summary>
        String Issuer { get; }

        /// <summary>
        /// Audience claim
        /// </summary>
        String Audience { get; }

    }
}
