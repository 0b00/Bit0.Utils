using System;
using Bit0.Utils.Common.Extensions;
using Bit0.Utils.JSend.Common;
using Newtonsoft.Json;

namespace Bit0.Utils.JSend.Responses
{
    /// <summary>
    /// JSend Response base
    /// </summary>
    public class JSendResponse : JSendResponse<Object>
    { }

    /// <summary>
    /// JSend Response base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JSendResponse<T> where T : class
    {
        /// <summary>
        /// JSend status
        /// </summary>
        [JsonIgnore]
        protected JSendStatus Status { private get; set; } = JSendStatus.Success;

        /// <summary>
        /// JSend status as string
        /// </summary>
        [JsonProperty("status")]
        public String StringStatus => Status.GetValue();

        /// <summary>
        /// JSend status code
        /// </summary>
        [JsonProperty("code")]
        public JSendStatusCode StatusCode { get; set; } = new JSendStatusCode();

        /// <summary>
        /// JSend error message
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public String Message { get; set; }

        /// <summary>
        /// JSend payload
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }
    }
}
