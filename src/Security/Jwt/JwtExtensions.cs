using System;
using System.Collections.Generic;
using Bit0.Utils.Common.Extensions;
using Bit0.Utils.JSend.Exceptions;

namespace Bit0.Utils.Security.Jwt
{

    public static class JwtExtensions
    {
        public static void ValidateDate(this IDictionary<string, object> jwt, string key, string errorMessage)
        {

            double epoch;
            try
            {
                epoch = (double)jwt[key];
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCredentialsException(new { message = "Invalid access token." }, ex);
            }

            if (epoch == 0)
            {
                throw new InvalidCredentialsException(new { message = "Invalid access token." });
            }

            if (key == JwtClaimKeys.Expiry ? epoch.ToUtc() <= DateTime.UtcNow : epoch.ToUtc() > DateTime.UtcNow)
            {
                throw new InvalidCredentialsException(new { message = string.Format(errorMessage, epoch.ToUtc().ToString("u")) });
            }
        }
    }
}