namespace Bit0.Utils.Data
{
    /// <summary>
    /// Interface for implementing mapping of objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapper<T> where T : IData
    {
        /// <summary>
        /// Map to a new object
        /// </summary>
        /// <returns>Mapped object</returns>
        T Map();

        /// <summary>
        /// Map to an exsiting object
        /// </summary>
        /// <param name="obj">Existing object</param>
        /// <returns>Mapped object</returns>
        T Map(T obj);
    }
}
