﻿using System;
using Bit0.Utils.Data.Exceptions;

namespace Bit0.Utils.Data.Reference
{
    /// <summary>
    /// Identity object
    /// </summary>
    public class DataReference : IEquatable<DataReference>
    {

        private const String GuidFormat = "D";

        /// <summary>
        /// String representation of Id
        /// </summary>
        public Guid Id { get; }

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
        private DataReference(Guid id)
        {
            Id = id;
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
        public static DataReference Empty => new DataReference(Guid.Empty);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="DataReference"/>
        /// </summary>
        /// <param name="id"></param>
        public static implicit operator DataReference(String id)
        {
            Guid guid;

            if (String.IsNullOrWhiteSpace(id))
            {
                id = Empty;
            }

            if (!Guid.TryParse(id, out guid))
            {
                throw new InvalidDataReferenceCastException(id);
            }

            return new DataReference(guid);
        }

        /// <summary>
        /// Convert <see cref="Guid"/> to <see cref="DataReference"/>
        /// </summary>
        /// <param name="id"></param>
        public static implicit operator DataReference(Guid id)
        {
            return new DataReference(id);
        }

        /// <summary>
        /// Convert <see cref="DataReference"/> to <see cref="string"/>
        /// </summary>
        /// <param name="id"></param>
        public static implicit operator String(DataReference id)
        {
            return id.ToString();
        }

        /// <summary>
        /// String representation of Id
        /// </summary>
        /// <param name="format">GUID Format, default "D"</param>
        /// <returns></returns>
        public String ToString(String format)
        {
            return Id.ToString(format);
        }

        /// <summary>
        /// String representation of Id
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return ToString(GuidFormat);
        }

        /// <summary>
        /// Check if <see cref="DataReference"/> is null or empty
        /// </summary>
        /// <param name="id"><see cref="DataReference"/> to check</param>
        /// <returns>true - if null or empty</returns>
        public static Boolean IsEmptyOrNull(DataReference id)
        {
            if (id == null)
                return true;

            return !(!String.IsNullOrWhiteSpace(id) && id.Id != Guid.Empty);
        }

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="DataReference"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataReference Parse(String id)
        {
            return id;
        }

        /// <summary>
        /// Try to convert <see cref="string"/> to <see cref="DataReference"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ref"></param>
        /// <returns></returns>
        public static Boolean TryParse(String id, out DataReference @ref)
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
        public Boolean Equals(DataReference other)
        {
            return other != null && Id.Equals(other.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Boolean Equals(Object obj)
        {
            var other = obj as DataReference;
            return other != null && Equals(other);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Int32 GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}