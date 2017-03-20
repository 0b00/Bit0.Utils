using System;

namespace Bit0.Utils.Common.Extensions
{
    /// <summary>
    /// <see cref="DateTime"/> extensions
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Covert <see cref="DateTime"/> to unix epoch
        /// </summary>
        /// <param name="dateTime">Date to convert</param>
        /// <returns></returns>
        public static double ToUnixEpoch(this DateTime dateTime)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Math.Round((dateTime - unixEpoch).TotalSeconds);
        }

        /// <summary>
        /// Convert unix epoch to <see cref="DateTime"/>
        /// </summary>
        /// <param name="unixEpoch"></param>
        /// <returns></returns>
        public static DateTime ToUtc(this double unixEpoch)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return date.AddSeconds(unixEpoch);
        }
    }
}
