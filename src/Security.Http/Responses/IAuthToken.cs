using System;

namespace Bit0.Utils.Security.Http.Responses
{
    /// <summary>
    /// Authentication token
    /// </summary>
    public interface IAuthToken
    {
        /// <summary>
        /// Token type
        /// </summary>
        /// <remarks>Should be <c>Bearer</c> in most cases</remarks>
        /// <remarks>json: <c>token_type</c></remarks>
        /// <example>
        /// Sample:
        /// <code>
        /// [JsonProperty("token_type")]
        /// public string TokenType { get; set; } = "Bearer";
        /// </code>
        /// </example>
        String TokenType { get; set; }

        /// <summary>
        /// Access token (json: access_token)
        /// </summary>
        String AccessToken { get; set; }

        /// <summary>
        /// Time token expires in, in seconds (json: expires_in)
        /// </summary>
        Int32 ExpiresIn { get; set; }

        /// <summary>
        /// Time refresh token expires in, in seconds (json: refresh_token)
        /// </summary>
        String RefreshToken { get; set; }
    }
}
