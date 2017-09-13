using System;
using System.Text;
using Jose;

namespace Bit0.Utils.Security.Jwt
{
    /// <summary>
    /// JsonWebToken encryption key wrapper for HMAC
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class JwtKeyHMAC : IJwtKey
    {
        /// <inheritdoc />
        public JwsAlgorithm Algorithm { get; set; }
        
        /// <inheritdoc />
        public Object Key => SecretKey;
        
        /// <inheritdoc />
        public Byte[] SecretKey { get; set; }

        /// <summary>
        /// JsonWebToken encryption key wrapper for HMAC
        /// </summary>
        /// <param name="key"></param>
        /// <param name="algo"></param>
        public JwtKeyHMAC(String key, JwsAlgorithm algo = JwsAlgorithm.HS512)
        {
            Algorithm = algo;
            SecretKey = Encoding.UTF8.GetBytes(key);
        }

        /// <summary>
        /// JsonWebToken encryption key wrapper for HMAC
        /// </summary>
        /// <param name="key"></param>
        /// <param name="algo"></param>
        public JwtKeyHMAC(Byte[] key, JwsAlgorithm algo = JwsAlgorithm.HS512)
        {
            Algorithm = algo;
            SecretKey = key;
        }
    }
}