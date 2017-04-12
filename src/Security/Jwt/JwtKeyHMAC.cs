using System;
using System.Text;
using Jose;

namespace Bit0.Utils.Security.Jwt
{

    public class JwtKeyHMAC : IJwtKey
    {
        public JwsAlgorithm Algorithm { get; set; } = JwsAlgorithm.HS512;

        public object Key => SecretKey;

        public byte[] SecretKey { get; set; }

        public JwtKeyHMAC(string key, JwsAlgorithm algo = JwsAlgorithm.HS512)
        {
            Algorithm = algo;
            SecretKey = Encoding.UTF8.GetBytes(key);
        }

        public JwtKeyHMAC(byte[] key, JwsAlgorithm algo = JwsAlgorithm.HS512)
        {
            Algorithm = algo;
            SecretKey = key;
        }
    }
}