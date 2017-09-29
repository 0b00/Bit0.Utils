using System;
using System.Collections.Generic;
using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.Common.Extensions;

namespace Bit0.Utils.Security.Jwt
{
    /// <summary>
    /// Extensions for Jwt
    /// </summary>
    public static class JwtExtensions
    {
        /// <summary>
        /// Validate 
        /// </summary>
        /// <param name="jwt"></param>
        /// <param name="key"></param>
        /// <param name="errorMessage"></param>
        /// <param name="utcNow"></param>
        public static void ValidateDate(this IDictionary<String, Object> jwt, String key, String errorMessage, DateTime? utcNow = null)
        {

            Double epoch;
            try
            {
                epoch = (Double)jwt[key];
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCredentialsException(new { message = "Invalid access token." }, ex);
            }

            var claimDate = epoch.ToUtc();

            if (key == JwtClaimKeys.Expiry ? claimDate <= utcNow : claimDate >= utcNow)
            {
                throw new InvalidCredentialsException(new { message = String.Format(errorMessage, epoch.ToUtc().ToString("u")) });
            }
        }
    }
}