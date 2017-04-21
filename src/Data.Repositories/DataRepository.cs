using System;
using System.Collections.Generic;
using System.Linq;
using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.Data.Providers;
using Bit0.Utils.Data.Reference;

namespace Bit0.Utils.Data.Repositories
{
    /// <summary>
    /// Data repository
    /// </summary>
    public class DataRepository<TData> : IDataRepository<TData> where TData : IData
    {
        /// <summary>
        /// Data context
        /// </summary>
        protected readonly IDataProvider DataProvider;

        /// <summary>
        /// Initialize a new instance of <see cref="DataRepository{TData}"/> class
        /// </summary>
        /// <param name="dataProvider">Data context</param>
        public DataRepository(IDataProvider dataProvider)
        {
            DataProvider = dataProvider;
        }

        /// <summary>
        /// Save or update data
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="data">Data to save</param>
        /// <returns><paramref name="data"/></returns>
        public T Save<T>(T data) where T : IData
        {
            var id = DataReference.IsEmptyOrNull(data.Id) ? DataProvider.Add(data) : DataProvider.Update(data);
            DataProvider.SaveChanges();

            return DataProvider.Entry<T>(id);
        }

        public TData Save(TData data)
        {
            return Save<TData>(data);
        }

        /// <summary>
        /// Save or update multiple rows
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="data">Data to save</param>
        /// <returns><paramref name="data"/></returns>
        public IEnumerable<T> Save<T>(IEnumerable<T> data) where T : IData
        {
            var res = new List<T>();

            if (data != null)
            {
                res.AddRange(data.Select(obj => DataReference.IsEmptyOrNull(obj.Id) ? DataProvider.Add(obj) : DataProvider.Update(obj))
                    .Select(id => DataProvider.Entry<T>(id)));
            }

            DataProvider.SaveChanges();

            return res;
        }

        public IEnumerable<TData> Save(IEnumerable<TData> data)
        {
            return Save<TData>(data);
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="data">Data to delete</param>
        public void Delete(IData data)
        {
            DataProvider.Remove(data);
            DataProvider.SaveChanges();
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="id">Id for data to delete</param>
        public void Delete(DataReference id)
        {
            DataProvider.Remove(id);
            DataProvider.SaveChanges();
        }

        /// <summary>
        /// List data
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <returns>Data from repository</returns>
        public IEnumerable<T> Find<T>() where T : IData
        {
            return DataProvider.Set<T>();
        }

        public IEnumerable<TData> Find()
        {
            return Find<TData>();
        }

        /// <summary>
        /// List data
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <returns>Data from repository</returns>
        public IEnumerable<T> Find<T>(Func<T, bool> predicate) where T : IData
        {
            return DataProvider.List(predicate);
        }

        public IEnumerable<TData> Find(Func<TData, bool> predicate)
        {
            return Find<TData>(predicate);
        }

        /// <summary>
        /// Get data
        /// </summary>
        /// <param name="predicate">Filter</param>
        /// <typeparam name="T">Element type</typeparam>
        /// <returns>Data from repository</returns>
        public T FindOne<T>(Func<T, bool> predicate) where T : IData
        {
            return Find(predicate).SingleOrDefault();
        }

        public TData FindOne(Func<TData, bool> predicate)
        {
            return FindOne<TData>(predicate);
        }

        /// <summary>
        /// Get object by Id
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="id">Id of object to fetch</param>
        /// <returns></returns>
        public T GetById<T>(string id) where T : IData
        {
            return GetById<T>(DataReference.Parse(id));
        }

        public TData GetById(string id)
        {
            return GetById<TData>(DataReference.Parse(id));
        }

        /// <summary>
        /// Get object by Id
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="id">Id of object to fetch</param>
        /// <returns></returns>
        public T GetById<T>(DataReference id) where T : IData
        {
            if (DataReference.IsEmptyOrNull(id))
                throw new ArgumentMissingException(nameof(id));

            return DataProvider.Entry<T>(id);
        }

        public TData GetById(DataReference id)
        {
            return GetById<TData>(id);
        }

        public DataReference ValidateId<T>(string id) where T : IData
        {
            var obj = GetById<T>(id);
            if (obj == null)
            {
                throw new KeyMissingException(typeof(T), id);
            }

            return obj.Id;
        }
    }
}
