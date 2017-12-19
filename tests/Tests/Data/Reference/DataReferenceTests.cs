using System;
using Bit0.Utils.Data.Exceptions;
using Bit0.Utils.Data.Reference;
using Xunit;

namespace Bit0.Utils.Tests.Data.Reference
{
    public class DataReferenceTests
    {
        [Fact]
        public void ImplicitFromString()
        {
            var str = Guid.NewGuid().ToString();
            DataReference id = str;

            Assert.Equal(str, id.ToString());
        }

        [Fact]
        public void ImplicitFromNullString()
        {
            var str = "";
            DataReference id = str;

            Assert.Equal(Guid.Empty, id.Id);
        }

        [Fact]
        public void InvalidReference()
        {
            Assert.Throws<InvalidDataReferenceCastException>(() =>
            {
                DataReference id = "a";
            });
        }

        [Fact]
        public void ImplicitFromGuid()
        {
            var guid = Guid.NewGuid();
            DataReference id = guid;

            Assert.Equal(guid, id.Id);
        }

        [Fact]
        public void NewIdentity()
        {
            var id = DataReference.NewIdentity();
            Assert.NotNull(id);
            Assert.NotNull(id.Id);
            Assert.Equal(id.Id, id);

            String str = id;
            Assert.Equal(id.ToString(), str);
        }
        
        [Fact]
        public void EmptyOrNull()
        {
            var id1 = DataReference.Empty;
            
            Assert.True(DataReference.IsEmptyOrNull(id1));
            Assert.True(DataReference.IsEmptyOrNull((DataReference) null));
        }

        [Fact]
        public void Test()
        {
            var str = DataReference.Empty;

            DataReference id = str;

            Assert.Equal(str.Id, id.Id);
        }

        [Fact]
        public void Parse()
        {
            var str = Guid.NewGuid().ToString();
            var id = DataReference.Parse(str);

            Assert.Equal(str, id.ToString());
        }

        [Fact]
        public void TryParse()
        {
            var str = Guid.NewGuid().ToString();
            var success = DataReference.TryParse(str, out DataReference id);

            Assert.True(success);
            Assert.Equal(str, id.ToString());

            Assert.Throws<InvalidDataReferenceCastException>(() =>
            {
                DataReference.TryParse("a", out id);
            });
        }

        [Fact]
        public void HashCode()
        {
            var guid = Guid.NewGuid();
            DataReference id = guid;

            Assert.Equal(guid.GetHashCode(), id.GetHashCode());
        }
        
        [Fact]
        public void Equals1()
        {
            var guid = Guid.NewGuid();
            DataReference id = guid;

            Object id2 = (DataReference) guid;

            Assert.True(id.Equals(id2));
        }
    }
}
