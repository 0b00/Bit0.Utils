using System;
using Bit0.Utils.Common.Data;
using Xunit;

namespace Bit0.Utils.Tests.Common.Data
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

        //[Fact]
        //public void ImplicitFromGuid()
        //{
        //    var guid = Guid.NewGuid();
        //    DataReference id = guid;

        //    Assert.Equal(guid, id.Id);
        //}

        [Fact]
        public void NewIdentity()
        {
            var id = DataReference.NewIdentity();
            Assert.NotNull(id);
            Assert.NotNull(id.Id);
            Assert.Equal(id.Id, id);

            string str = id;
            Assert.Equal(id.ToString(), str);
        }
        
        [Fact]
        public void EmptyOrNull()
        {
            var id1 = DataReference.Empty;

            DataReference id2 = null;
            
            Assert.True(DataReference.IsEmptyOrNull(id1));
            Assert.True(DataReference.IsEmptyOrNull(id2));
        }

        [Fact]
        public void Test()
        {
            var str = DataReference.Empty;

            DataReference id = str;

            Assert.Equal(str.Id, id.Id);
        }
    }
}
