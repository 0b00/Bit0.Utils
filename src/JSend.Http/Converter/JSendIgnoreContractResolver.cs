using System.Linq;
using System.Reflection;
using Bit0.Utils.JSend.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bit0.Utils.JSend.Http.Converter
{
    /// <summary>
    /// Ignore contract
    /// </summary>
    public class JSendIgnoreContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Ignore contract
        /// </summary>
        public JSendIgnoreContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy
            {
                ProcessDictionaryKeys = true,
                OverrideSpecifiedNames = true
            };
        }

        /// <inheritdoc />
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (member.GetCustomAttributes(typeof(JSendIgnoreAttribute), true).Any())
            {
                property.ShouldSerialize = (instance) => false;
            }

            return property;
        }
    }
}
