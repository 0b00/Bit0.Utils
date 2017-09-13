using System;
using System.Collections.Generic;
using System.Linq;
using Bit0.Utils.Data.Reference;

namespace Bit0.Utils.Data.Providers
{
    /// <summary>
    /// Interface for data context
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Get a set from the database, filtered on supplied <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Element type to filter</typeparam>
        /// <returns></returns>
        IQueryable<T> Set<T>() where T : IData;

        /// <summary>
        /// Get a list from database, filtered on supplied <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Element type to filter</typeparam>
        /// <param name="predicate">Filter</param>
        /// <returns></returns>
        IEnumerable<T> List<T>(Func<T, Boolean> predicate) where T : IData;

        /// <summary>
        /// Get a single entry by <paramref name="id"/> of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Filter and cast to type</typeparam>
        /// <param name="id">Id to get</param>
        /// <returns>En entry from database</returns>
        T Entry<T>(DataReference id) where T : IData;

        /// <summary>
        /// Add a new entry to database
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="data">Element to save</param>
        /// <returns>Id of newly saved <paramref name="data"/></returns>
        DataReference Add<T>(T data) where T : IData;

        /// <summary>
        /// Update an exsiting entry
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="data">Element to update</param>
        /// <returns>If of the element</returns>
        DataReference Update<T>(T data) where T : IData;

        /// <summary>
        /// Remove element by id
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="id">Id of element to remove</param>
        void Remove<T>(DataReference id) where T : IData;

        /// <summary>
        /// Remove element
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="data">Element to remove</param>
        void Remove<T>(T data) where T : IData;

        /// <summary>
        /// Save changes to database, leave empty if not needed
        /// </summary>
        /// <param name="force">Force save</param>
        void SaveChanges(Boolean force = false);
    }
}
