using System;

namespace Bit0.Utils.Common.Data
{
    /// <summary>
    /// Identity object
    /// </summary>
    public class DataReference : IEquatable<DataReference>
    {

        private const string _guidFormat = "D";

        /// <summary>
        /// String representation of Id
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Create a new instance of <see cref="DataReference"/>
        /// </summary>
        public DataReference()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Create a new instance of <see cref="DataReference"/>
        /// </summary>
        /// <returns></returns>
        public static DataReference NewIdentity()
        {
            return new DataReference();
        }

        /// <summary>
        /// Empty <see cref="DataReference"/>
        /// </summary>
        /// <returns></returns>
        public static DataReference Empty => new DataReference
        {
            Id = Guid.Empty
        };

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="DataReference"/>
        /// </summary>
        /// <param name="id"></param>
        public static implicit operator DataReference(string id)
        {
            Guid guid;

            if (string.IsNullOrWhiteSpace(id))
            {
                id = Empty;
            }

            if (!Guid.TryParse(id, out guid))
            {
                throw new InvalidDataReferenceCastException(id);
            }

            return new DataReference
            {
                Id = guid
            };
        }

        /// <summary>
        /// Convert <see cref="Guid"/> to <see cref="DataReference"/>
        /// </summary>
        /// <param name="id"></param>
        public static implicit operator DataReference(Guid id)
        {
            return new DataReference
            {
                Id = id
            };
        }

        /// <summary>
        /// Convert <see cref="DataReference"/> to <see cref="string"/>
        /// </summary>
        /// <param name="id"></param>
        public static implicit operator string(DataReference id)
        {
            return id.ToString();
        }

        /// <summary>
        /// String representation of Id
        /// </summary>
        /// <param name="format">GUID Format, default "D"</param>
        /// <returns></returns>
        public string ToString(string format)
        {
            return Id.ToString(format);
        }

        /// <summary>
        /// String representation of Id
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString(_guidFormat);
        }

        /// <summary>
        /// Check if <see cref="DataReference"/> is null or empty
        /// </summary>
        /// <param name="id"><see cref="DataReference"/> to check</param>
        /// <returns>true - if null or empty</returns>
        public static bool IsEmptyOrNull(DataReference id)
        {
            if (id == null)
                return true;

            return !(!string.IsNullOrWhiteSpace(id) && id.Id != Guid.Empty);
        }

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="DataReference"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataReference Parse(string id)
        {
            return id;
        }

        /// <summary>
        /// Try to convert <see cref="string"/> to <see cref="DataReference"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ref"></param>
        /// <returns></returns>
        public static bool TryParse(string id, out DataReference @ref)
        {
            @ref = null;
            try
            {
                @ref = id;

                return true;
            }
            catch (Exception e)
            {
                throw new InvalidDataReferenceCastException(id, e);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(DataReference other)
        {
            return  other != null && Id.Equals(other.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as DataReference;
            return other != null && Equals(other);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}