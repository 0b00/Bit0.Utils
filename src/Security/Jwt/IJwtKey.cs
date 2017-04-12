using Jose;

namespace Bit0.Utils.Security.Jwt
{

    public interface IJwtKey
    {
        JwsAlgorithm Algorithm { get; set; }
        object Key { get; }
    }
}