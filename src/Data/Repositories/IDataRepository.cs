using System;
using System.Collections.Generic;
using Bit0.Utils.Data.Reference;

namespace Bit0.Utils.Data.Repositories
{
    /// <summary>
    /// Interface for data repository
    /// </summary>
    public interface IDataRepository<TData> where TData : IData
    {
        /// <summary>
        /// Save or update data
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="data">Data to save</param>
        /// <returns><paramref name="data"/></returns>
        T Save<T>(T data) where T : IData;

        /// <summary>
        /// Save Data
        /// </summary>
        /// <param name="data">Data to save</param>
        /// <returns></returns>
        TData Save(TData data);

        /// <summary>
        /// Save or update multiple rows
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="data">Data to save</param>
        /// <returns><paramref name="data"/></returns>
        IEnumerable<T> Save<T>(IEnumerable<T> data) where T : IData;

        /// <summary>
        /// Save or update multiple rows
        /// </summary>
        /// <param name="data">Data to save</param>
        /// <returns></returns>
        IEnumerable<TData> Save(IEnumerable<TData> data);

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="data">Data to delete</param>
        void Delete(IData data);

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="id">Id for data to delete</param>
        void Delete(DataReference id);

        /// <summary>
        /// List data
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <returns>Data from repository</returns>
        IEnumerable<T> Find<T>() where T : IData;

        /// <summary>
        /// List data
        /// </summary>
        /// <returns>Data from repository</returns>
        IEnumerable<TData> Find();

        /// <summary>
        /// List data
        /// </summary>
        /// <param name="predicate">Filter</param>
        /// <typeparam name="T">Element type</typeparam>
        /// <returns>Data from repository</returns>
        IEnumerable<T> Find<T>(Func<T, Boolean> predicate) where T : IData;

        /// <summary>
        /// List data
        /// </summary>
        /// <param name="predicate">Filter</param>
        /// <returns></returns>
        IEnumerable<TData> Find(Func<TData, Boolean> predicate);

        /// <summary>
        /// Get data
        /// </summary>
        /// <param name="predicate">Filter</param>
        /// <typeparam name="T">Element type</typeparam>
        /// <returns>Data from repository</returns>
        T FindOne<T>(Func<T, Boolean> predicate) where T : IData;

        /// <summary>
        /// Get Data
        /// </summary>
        /// <param name="predicate">Filter</param>
        /// <returns>Data from repository</returns>
        TData FindOne(Func<TData, Boolean> predicate);

        /// <summary>
        /// Get object by Id
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="id">Id of object to fetch</param>
        /// <returns></returns>
        T GetById<T>(String id) where T : IData;

        /// <summary>
        /// Get object by Id
        /// </summary>
        /// <param name="id"><see cref="DataReference"/> of object to fetch</param>
        /// <returns></returns>
        TData GetById(String id);


        /// <summary>
        /// Get object by Id
        /// </summary>
        /// <param name="id"><see cref="DataReference"/> of object to fetch</param>
        /// <typeparam name="T">Element type</typeparam>
        /// <returns></returns>
        T GetById<T>(DataReference id) where T : IData;

        /// <summary>
        /// Get object by Id
        /// </summary>
        /// <param name="id"><see cref="DataReference"/> of object to fetch</param>
        /// <returns></returns>
        TData GetById(DataReference id);

        /// <summary>
        /// Validate id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Id to validate</param>
        /// <returns></returns>
        DataReference ValidateId<T>(String id) where T : IData;
    }
}