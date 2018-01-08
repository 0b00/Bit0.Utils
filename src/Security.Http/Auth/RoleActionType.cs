using Bit0.Utils.Common.Attributes;

namespace Bit0.Utils.Security.Http.Auth
{
    /// <summary>
    /// Role actions
    /// </summary>

    // Note: if you need to add a new type, update All under special region
    public enum RoleActionType
    {
        #region On Current Item

        /// <summary>
        /// Create item
        /// </summary>
        [String("Create")]
        Create = 1,
        /// <summary>
        /// Read item
        /// </summary>
        [String("Read")]
        Read = 2,
        /// <summary>
        /// Update item
        /// </summary>
        [String("Update")]
        Update = 4,
        /// <summary>
        /// Delete item
        /// </summary>
        [String("Delete")]
        Delete = 8,

        #endregion

        #region Add to current item list

        /// <summary>
        /// Add to list
        /// </summary>
        [String("Add")]
        Add = 16,
        /// <summary>
        /// Remove from list
        /// </summary>
        [String("Remove")]
        Remove = 32,

        #endregion

        #region Sync

        /// <summary>
        /// Sync item
        /// </summary>
        [String("Sync")]
        Sync = 64,

        #endregion

        #region Special

        /// <summary>
        /// All rights
        /// </summary>
        /// <remarks>Should be used very carefully. Use full for admins.</remarks>
        [String("All")]
        All = Create | Read | Update | Delete | Add | Remove | Sync,

        /// <summary>
        /// None
        /// </summary>
        [String("None")]
        None = -1,

        #endregion
    }
}
