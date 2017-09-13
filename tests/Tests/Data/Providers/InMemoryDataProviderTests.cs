using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.Data;
using Bit0.Utils.Data.Providers;
using Bit0.Utils.Data.Reference;
using System;
using System.Linq;
using Xunit;

namespace Bit0.Utils.Tests.Data.Providers
{
    public class InMemoryDataProviderTests
    {
        private readonly IDataProvider _dataProvider;

        public InMemoryDataProviderTests()
        {
            _dataProvider = new InMemoryDataProvider();
        }

        [Fact]
        public void LoadAndSave()
        {
            _dataProvider.SaveChanges();

            var ex = new InMemoryDataProviderEx();
            ex.Load();

            var data = ex.List<IData>(x => true).ToList();

            Assert.Equal(0, data.Count);
        }

        [Fact]
        public void Add()
        {
            var user0 = new User
            {
                Username = "user0",
            };

            var id = _dataProvider.Add(user0);

            Assert.NotNull(id);
            Assert.False(DataReference.IsEmptyOrNull(id));

            // test null
            Assert.Throws<NullObjectException>(() =>
            {
                _dataProvider.Add((User) null);
            });

            //Update
            user0.Password = "T";
            _dataProvider.Add(user0);
        }

        [Fact]
        public void GetEntry()
        {
            var user1 = new User
            {
                Username = "user1",
            };

            var id = _dataProvider.Add(user1);

            var rUser = _dataProvider.Entry<User>(id);
            Assert.False(DataReference.IsEmptyOrNull(user1.Id));

            Assert.NotNull(rUser);
            Assert.Equal(user1.Username, rUser.Username);
        }

        [Fact]
        public void GetSet()
        {
            var username = "user1a";

            var user1A = new User
            {
                Username = username,
            };

            _dataProvider.Add(user1A);

            var rUser = _dataProvider.Set<User>().FirstOrDefault(x => x.Username.Equals(username));

            Assert.NotNull(rUser);
            Assert.Equal(username, rUser.Username);
        }

        [Fact]
        public void GetList()
        {
            var username = "user1b";

            var user1A = new User
            {
                Username = username,
            };

            _dataProvider.Add(user1A);

            var rUser = _dataProvider.List<User>(x => x.Username.Equals(username)).FirstOrDefault();

            Assert.NotNull(rUser);
            Assert.Equal(username, rUser.Username);
        }

        [Fact]
        public void Update()
        {
            var pass = "pass";
            var pass2 = "pass2";

            var user2 = new User
            {
                Username = "user2",
                Password = pass
            };

            var id = _dataProvider.Add(user2);

            Assert.NotNull(id);
            Assert.False(DataReference.IsEmptyOrNull(id));

            var rUser = _dataProvider.Entry<User>(id);
            rUser.Password = pass2;
            var rId = _dataProvider.Update(rUser);
            var rUser2 = _dataProvider.Entry<User>(rId);

            Assert.Equal(id, rId);
            Assert.NotEqual(pass, rUser2.Password);
            Assert.Equal(pass2, rUser2.Password);

            // test null
            Assert.Throws<NullObjectException>(() =>
            {
                _dataProvider.Update((User)null);
            });

            // add
            var user3 = new User
            {
                Id = DataReference.NewIdentity(),
                Username = "user2",
                Password = pass
            };

            var id3 = _dataProvider.Update(user3);

            Assert.NotNull(id3);
            Assert.False(DataReference.IsEmptyOrNull(id3));
        }

        [Fact]
        public void Remove()
        {
            var user3 = new User
            {
                Username = "user3"
            };
            var user4 = new User
            {
                Username = "user4"
            };

            var id3 = _dataProvider.Add(user3);
            _dataProvider.Remove<IData>(id3);

            Assert.Throws(typeof(KeyMissingException), () =>
            {
                var rUser3 = _dataProvider.Entry<User>(id3);
                Assert.Null(rUser3);
            });

            var id4 = _dataProvider.Add(user4);
            var rUser4 = _dataProvider.Entry<User>(id4);
            _dataProvider.Remove(rUser4);

            Assert.Throws(typeof(KeyMissingException), () =>
            {
                rUser4 = _dataProvider.Entry<User>(id4);
            });

            Assert.Throws<NullObjectException>(() =>
            {
                _dataProvider.Remove<IData>((User)null);
            });

            Assert.Throws<KeyMissingException>(() =>
            {
                _dataProvider.Remove<IData>(id3);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                _dataProvider.Remove<IData>(new User());
            });
            
            Assert.Throws<KeyMissingException>(() =>
            {
                _dataProvider.Remove<IData>(rUser4);
            });
        }

        [Fact]
        public void AddwithId()
        {
            var id = DataReference.NewIdentity();
            var user = new User
            {
                Id = id,
                Username = "userx"
            };

            var rid = _dataProvider.Add(user);


            Assert.NotNull(rid);
            Assert.False(DataReference.IsEmptyOrNull(rid));
            Assert.Equal<String>(id, rid);
        }

        private class InMemoryDataProviderEx : InMemoryDataProvider
        {
            public void Load()
            {
                LoadData();
            }
        }
    }
}
