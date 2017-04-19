using System;
using Bit0.Utils.JSend.Responses;

namespace Bit0.Utils.JSend.Attributes
{
    /// <summary>
    /// Ignore properties in <see cref="JSendResponse"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class JSendIgnoreAttribute : Attribute
    { }
}
