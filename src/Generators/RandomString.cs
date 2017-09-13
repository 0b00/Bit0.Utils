using System;
using System.Security.Cryptography;

namespace Bit0.Utils.Generators
{
    /// <summary>
    /// Generate random string
    /// </summary>
    public static class RandomString
    {
        private static readonly Random Random = new Random();
        private static readonly RandomNumberGenerator NumberGenerator = RandomNumberGenerator.Create();

        /// <summary>
        /// Generate random string
        /// </summary>
        /// <param name="length">Generated strings length</param>
        /// <param name="upper">Include uppercase</param>
        /// <param name="numbers">Include numbers</param>
        /// <param name="special">Include special characters</param>
        /// <returns>A random string</returns>
        public static String Generate(Int32 length, Boolean upper, Boolean numbers, Boolean special)
        {
            var len0 = Random.Next(1, 3 + 1);
            var len1 = special ? Random.Next(1, 2 + 1) : 0;
            var len2 = numbers ? Random.Next(1, 2 + 1) : 0;
            var len3 = upper ? (length - len1 - len2) / 2 : 0;
            var len4 = length - len1 - len2 - len3;

            var chars1 = "!@#$%^&/?-_=".ToCharArray();
            var chars2 = "0123456789".ToCharArray();
            var chars3 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            var chars4 = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var data1 = new Byte[len1];
            var data2 = new Byte[len2];
            var data3 = new Byte[len3];
            var data4 = new Byte[len4];

            var result1 = new Char[len1];
            var result2 = new Char[len2];
            var result3 = new Char[len3];
            var result4 = new Char[len4];

            NumberGenerator.GetBytes(data1);
            NumberGenerator.GetBytes(data2);
            NumberGenerator.GetBytes(data3);
            NumberGenerator.GetBytes(data4);

            for (var i = 0; i < len1; i++)
            {
                result1[i] = chars1[data1[i] % (chars1.Length)];
            }
            for (var i = 0; i < len2; i++)
            {
                result2[i] = chars2[data2[i] % (chars2.Length)];
            }
            for (var i = 0; i < len3; i++)
            {
                result3[i] = chars3[data3[i] % (chars3.Length)];
            }
            for (var i = 0; i < len4; i++)
            {
                result4[i] = chars4[data4[i] % (chars4.Length)];
            }

            var part1 = new String(result1);
            var part2 = new String(result2);
            var part3 = new String(result3) + new String(result4);

            var key = part3.Substring(0, len0) + part2 + part3.Substring(len0, len0) + part1 + part3.Substring(len0 * 2, (len3 + len4) - (len0 * 2));

            return key;
        }
    }
}
