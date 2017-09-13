using System;

namespace Bit0.Utils.Generators
{
    /// <summary>
    /// Generate random password. Based on <seealso cref="RandomString"/>
    /// </summary>
    public static class Password
    {
        /// <summary>
        /// Generate random password. Based on <seealso cref="RandomString"/>
        /// </summary>
        /// <param name="length">Password length</param>
        /// <param name="upper">Include uppercase</param>
        /// <param name="numbers">Include numbers</param>
        /// <param name="special">Include </param>
        /// <returns></returns>
        public static String Generate(Int32 length = 12, Boolean upper = true, Boolean numbers = true, Boolean special = true)
        {
            return RandomString.Generate(length, upper, numbers, special);
        }
    }
}
