using System;
using System.Collections.Generic;
using System.Linq;
using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.Data.Reference;

namespace Bit0.Utils.Data.Providers
{
    /// <summary>
    /// An in memory database, based on <see cref="IDataProvider" /> 
    /// </summary>
    public class InMemoryDataProvider : IDataProvider
    {
        #region Public Constructors

        /// <summary>
        /// Initialize a new instance of <see cref="InMemoryDataProvider" /> class 
        /// </summary>
        // ReSharper disable once EmptyConstructor
        public InMemoryDataProvider()
        { }

        #endregion Public Constructors



        #region Protected Properties
        /// <summary>
        /// Data List
        /// </summary>
        protected IDictionary<string, IData> DataList { get; } = new Dictionary<string, IData>();

        #endregion Protected Properties



        #region Protected Methods

        /// <summary>
        /// Load Data
        /// </summary>
        protected virtual void LoadData()
        {
            // load from where
        }

        #endregion Protected Methods



        #region Public Methods

        /// <summary>
        /// Add a new entry to database 
        /// </summary>
        /// <typeparam name="T">
        /// Element type 
        /// </typeparam>
        /// <param name="data">
        /// Element to save 
        /// </param>
        /// <returns>
        /// Id of newly saved <paramref name="data" /> 
        /// </returns>
        public DataReference Add<T>(T data) where T : IData
        {
            if (data == null)
            {
                throw new NullObjectException(nameof(data));
            }

            if (!DataReference.IsEmptyOrNull(data.Id) && DataList.ContainsKey(data.Id))
            {
                return Update(data);
            }

            if (DataReference.IsEmptyOrNull(data.Id))
            {
                data.Id = DataReference.NewIdentity();
            }

            DataList.Add(data.Id, data);

            return data.Id;
        }

        /// <summary>
        /// Get a single entry by <paramref name="id" /> of type <typeparamref name="T" /> 
        /// </summary>
        /// <typeparam name="T">
        /// Filter and cast to type 
        /// </typeparam>
        /// <param name="id">
        /// Id to get 
        /// </param>
        /// <returns>
        /// En entry from database 
        /// </returns>
        public T Entry<T>(DataReference id) where T : IData
        {
            if (DataList.ContainsKey(id))
            {
                return (T)DataList[id];
            }

            throw new KeyMissingException(nameof(id));
        }

        /// <summary>
        /// Get a list from database, filtered on supplied <typeparamref name="T" />. 
        /// </summary>
        /// <typeparam name="T">
        /// Element type to filter 
        /// </typeparam>
        /// <param name="predicate">
        /// Filter 
        /// </param>
        /// <returns>
        /// </returns>
        public IEnumerable<T> List<T>(Func<T, bool> predicate) where T : IData
        {
            return Set<T>().Where(predicate).AsEnumerable();
        }

        /// <summary>
        /// Remove element by id 
        /// </summary>
        /// <param name="id">
        /// Id of element to remove 
        /// </param>
        public void Remove(DataReference id)
        {
            if (DataList.ContainsKey(id))
            {
                DataList.Remove(id);
            }
            else
            {
                throw new KeyMissingException(nameof(id));
            }
        }

        /// <summary>
        /// Remove element 
        /// </summary>
        /// <typeparam name="T">
        /// Element type 
        /// </typeparam>
        /// <param name="data">
        /// Element to remove 
        /// </param>
        public void Remove<T>(T data) where T : IData
        {
            if (data == null)
            {
                throw new NullObjectException(nameof(data));
            }

            if (!DataList.ContainsKey(data.Id))
            {
                throw new KeyMissingException(nameof(data.Id));
            }

            Remove((DataReference)data.Id);
        }

        /// <summary>
        /// Save changes to database, leave empty if not needed
        /// </summary>
        /// <param name="force">Force changes</param>
        public virtual void SaveChanges(bool force = false)
        {
            // save where!!! its in the memory ;-P
        }

        /// <summary>
        /// Get a set from the database, filtered on supplied <typeparamref name="T" />. 
        /// </summary>
        /// <typeparam name="T">
        /// Element type to filter 
        /// </typeparam>
        /// <returns>
        /// </returns>
        public IQueryable<T> Set<T>() where T : IData
        {
            return DataList.Values.OfType<T>().AsQueryable();
        }

        /// <summary>
        /// Update an exsiting entry 
        /// </summary>
        /// <typeparam name="T">
        /// Element type 
        /// </typeparam>
        /// <param name="data">
        /// Element to update 
        /// </param>
        /// <returns>
        /// If of the element 
        /// </returns>
        public DataReference Update<T>(T data) where T : IData
        {
            if (data == null)
            {
                throw new NullObjectException(nameof(data));
            }

            if (!DataList.ContainsKey(data.Id))
            {
                return Add(data);
            }

            DataList[data.Id] = data;
            return data.Id;
        }

        #endregion Public Methods
    }
}