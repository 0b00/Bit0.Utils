using Jose;

namespace Bit0.Utils.Security.Jwt
{
    /// <summary>
    /// Interface for JsonWebToken encryption key wrapper
    /// </summary>
    public interface IJwtKey
    {
        /// <summary>
        /// Encryption algorithm
        /// </summary>
        JwsAlgorithm Algorithm { get; set; }

        /// <summary>
        /// Encryption key
        /// </summary>
        object Key { get; }
    }
}