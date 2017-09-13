using System;
using Bit0.Utils.JSend.Responses;
using Newtonsoft.Json;

namespace Bit0.Utils.JSend.Extensions
{
    /// <summary>
    /// JSend response extensions
    /// </summary>
    public static class JSendResponseExtensions
    {
        /// <summary>
        /// Convert JSend response to Json
        /// </summary>
        /// <param name="response">JSend to convert</param>
        /// <returns></returns>
        public static String ToJson(this JSendResponse response)
        {
            return JsonConvert.SerializeObject(response);
        }
    }
}
