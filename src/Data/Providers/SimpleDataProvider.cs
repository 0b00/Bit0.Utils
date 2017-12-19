using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Bit0.Utils.Data.Reference;
using Newtonsoft.Json;

namespace Bit0.Utils.Data.Providers
{
    /// <summary>
    /// An in memory database cached to disk, based on <see cref="IDataProvider" /> 
    /// </summary>
    public class SimpleDataProvider : InMemoryDataProvider
    {
        #region Protected Fields
        /// <summary>
        /// Storeage file
        /// </summary>
        protected readonly String StorageFilePath;
        #endregion

        #region Private Fields

        private readonly Int32 _maxTransBeforeWrite;
        private Int32 _operationsCount;
        private readonly JsonSerializerSettings _jsonSettings;

        #endregion Private Fields

        // has to be min 1

        #region Public Constructors

        /// <summary>
        /// Initialize a new instance of <see cref="SimpleDataProvider" /> class 
        /// </summary>
        /// <param name="maxTransBeforeWrite">Wait max saves before writing to file</param>
        /// <param name="storageFile">Storage file</param>
        public SimpleDataProvider(Int32 maxTransBeforeWrite = 1, String storageFile = null)
        {
            _jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };
            _jsonSettings.Converters.Add(new DataReferenceJsonConverter());

            _maxTransBeforeWrite = maxTransBeforeWrite >= 1 ? maxTransBeforeWrite : 1;

            StorageFilePath = !String.IsNullOrWhiteSpace(storageFile)
                ? storageFile
                : $"{nameof(SimpleDataProvider)}.Data.json";
            LoadData();
        }

        #endregion Public Constructors



        #region Protected Methods
        /// <summary>
        /// Loads data from file
        /// </summary>
        protected sealed override void LoadData()
        {
            DataList.Clear();

            var storageFile = new FileInfo(StorageFilePath);

            if (storageFile.Exists && StorageFilePath.Length > 20)
            {

                IDictionary<String, IData> list;
                using (var sr = storageFile.OpenText())
                {
                    var str = sr.ReadToEnd();
                    list = JsonConvert.DeserializeObject<IDictionary<String, IData>>(str, _jsonSettings);
                    //list = (IDictionary<string, object>) _serializer.Deserialize(sr, typeof(IDictionary<string, object>));
                }

                foreach (var item in list)
                {
                    DataList.Add(item.Key, item.Value);
                }
            }
        }
        #endregion Protected Methods

        #region Public Methods
        /// <summary>
        /// Save data to file
        /// </summary>
        /// <param name="force">Force save to file</param>
        public override void SaveChanges(Boolean force = false)
        {
            if (_operationsCount % _maxTransBeforeWrite == 0 || force)
            {
                SaveChangesAsync();
                _operationsCount = 0;
            }

            _operationsCount++;
        }

        /// <summary>
        /// Save data to file
        /// </summary>
        public Task SaveChangesAsync()
        {
            return Task.Run(() =>
            {
                var storageFile = new FileInfo(StorageFilePath);

                using (var sw = storageFile.CreateText())
                {
                    sw.Write(JsonConvert.SerializeObject(DataList, _jsonSettings));

                    //_serializer.Serialize(sw, DataList);
                }
            });
        }

        #endregion Public Methods
    }
}