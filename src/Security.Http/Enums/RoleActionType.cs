using Bit0.Utils.Common.Attributes;

namespace Bit0.Utils.Security.Http.Enums
{
    /// <summary>
    /// Role actions
    /// </summary>
    public enum RoleActionType
    {
        /// <summary>
        /// None
        /// </summary>
        [String("None")]
        None = 0,
        /// <summary>
        /// All
        /// <remarks>Should be used very carefully.</remarks>
        /// </summary>
        [String("All")]
        All = 1,

        /// <summary>
        /// Create
        /// </summary>
        [String("Create")]
        Create = 2,
        /// <summary>
        /// Read
        /// </summary>
        [String("Read")]
        Read = 4,
        /// <summary>
        /// Update
        /// </summary>
        [String("Update")]
        Update = 8,
        /// <summary>
        /// Delete
        /// </summary>
        [String("Delete")]
        Delete = 16,


        /// <summary>
        /// Add
        /// </summary>
        [String("Add")]
        Add = 32,
        /// <summary>
        /// Remove
        /// </summary>
        [String("Remove")]
        Remove = 64,

        /// <summary>
        /// Sync
        /// </summary>
        [String("Sync")]
        Sync = 128
    }
}
