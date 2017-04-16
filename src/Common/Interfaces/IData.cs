using System;

// ReSharper disable once CheckNamespace
namespace Bit0.Utils.Common
{
    /// <summary>
    /// Entity object
    /// </summary>
    public interface IData
    {
        /// <summary>
        /// <see cref="IData"/> Id
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Created timestamp
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Updated timestamp
        /// </summary>
        DateTime UpdatedOn { get; set; }
    }
}
