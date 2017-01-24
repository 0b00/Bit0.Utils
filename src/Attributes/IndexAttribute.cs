using System;

namespace SmartOrder.Attributes
{
    /// <summary>
    /// Mark a property as index
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IndexAttribute : Attribute
    {
    }
}
