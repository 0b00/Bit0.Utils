using Bit0.Utils.Common.Extensions;
using Bit0.Utils.JSend.Common;
using Newtonsoft.Json;

namespace Bit0.Utils.JSend.Responses
{
    /// <summary>
    /// JSend Response base
    /// </summary>
    public abstract class JSendResponse
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
        public string StringStatus => Status.GetValue();

        /// <summary>
        /// JSend status code
        /// </summary>
        [JsonProperty("code")]
        public JSendStatusCode StatusCode { get; set; } = new JSendStatusCode();

        /// <summary>
        /// JSend error message
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>
        /// JSend payload
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }
    }
}
