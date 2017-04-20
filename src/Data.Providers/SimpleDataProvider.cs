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
        #region Private Fields

        private readonly int _maxTransBeforeWrite;
        private readonly FileInfo _storageFile;
        private int _operationsCount;
        private readonly JsonSerializerSettings _jsonSettings;

        #endregion Private Fields

        // has to be min 1

        #region Public Constructors

        /// <summary>
        /// Initialize a new instance of <see cref="SimpleDataProvider" /> class 
        /// </summary>
        /// <param name="maxTransBeforeWrite">Wait max saves before writing to file</param>
        public SimpleDataProvider(int maxTransBeforeWrite = 1)
        {
            _jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };
            _jsonSettings.Converters.Add(new DataReferenceJsonConverter());

            _maxTransBeforeWrite = maxTransBeforeWrite >= 1 ? maxTransBeforeWrite : 1;

            _storageFile = new FileInfo("SimpleDataProvider.Data.json");
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

            if (_storageFile.Exists && _storageFile.Length > 20)
            {

                IDictionary<string, IData> list;
                using (var sr = _storageFile.OpenText())
                {
                    var str = sr.ReadToEnd();
                    list = JsonConvert.DeserializeObject<IDictionary<string, IData>>(str, _jsonSettings);
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
        public override void SaveChanges(bool force = false)
        {
            if (_operationsCount % _maxTransBeforeWrite == 0 || force)
            {
                Task.Run(() =>
                {
                    using (var sw = _storageFile.CreateText())
                    {
                        sw.Write(JsonConvert.SerializeObject(DataList, _jsonSettings));

                        //_serializer.Serialize(sw, DataList);
                    }
                });
                _operationsCount = 0;
            }

            _operationsCount++;
        }

        #endregion Public Methods
    }
}