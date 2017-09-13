using System;

namespace Bit0.Utils.Data
{
    /// <summary>
    /// Entity object
    /// </summary>
    public interface IData
    {
        /// <summary>
        /// <see cref="IData"/> Id
        /// </summary>
        String Id { get; set; }

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
