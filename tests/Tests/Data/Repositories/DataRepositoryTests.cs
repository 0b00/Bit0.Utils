using System;
using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.Data;
using Bit0.Utils.Data.Providers;
using Bit0.Utils.Data.Repositories;
using Bit0.Utils.Tests.Data.Providers;
using System.Collections.Generic;
using System.Linq;
using Bit0.Utils.Data.Reference;
using Xunit;

namespace Bit0.Utils.Tests.Data.Repositories
{
    public class DataRepositoryTests
    {
        private readonly IDataRepository<IData> _repository;

        public DataRepositoryTests()
        {
            var dataProvider = new InMemoryDataProvider();
            _repository = new DataRepository<IData>(dataProvider);
        }

        [Fact]
        public void Save()
        {
            var user = new User
            {
                Username = "user1",
                Password = "user1"
            };

            user = _repository.Save(user);

            Assert.NotNull(user);


            IData user1 = new User
            {
                Username = "user1a",
                Password = "user1a"
            };

            user1 = _repository.Save(user1);

            Assert.NotNull(user1);
        }

        [Fact]
        public void Update()
        {

            var user = new User
            {
                Username = "user2",
                Password = "user2"
            };
            user = _repository.Save(user);

            Assert.NotNull(user);
            Assert.True(string.IsNullOrWhiteSpace(user.Address));

            var address = "Street 1";
            user.Address = address;
            user = _repository.Save(user);

            Assert.False(string.IsNullOrWhiteSpace(user.Address));
            Assert.Equal(address, user.Address);
        }

        [Fact]
        public void SaveRangeT()
        {
            var users = new List<User>();
            for (var i = 0; i < 5; i++)
            {
                var user = new User
                {
                    Username = "user" + i,
                    Password = "pass" + i
                };

                users.Add(user);
            }

            var rUsers = _repository.Save<User>(users).ToList();

            Assert.NotNull(rUsers);
            Assert.NotEmpty(rUsers);
            Assert.Equal(users.Count, rUsers.Count);
            Assert.Equal(users, rUsers);

            _repository.Save((IEnumerable<IData>) null);
        }

        [Fact]
        public void SaveRange()
        {
            var users = new List<IData>();
            for (var i = 0; i < 5; i++)
            {
                var user = new User
                {
                    Username = "user" + i,
                    Password = "pass" + i
                };

                users.Add(user);
            }

            var rUsers = _repository.Save(users.Cast<IData>()).ToList();

            Assert.NotNull(rUsers);
            Assert.NotEmpty(rUsers);
            Assert.Equal(users.Count, rUsers.Count);
            Assert.Equal(users, rUsers);
        }

        [Fact]
        public void UpdateRange()
        {
            var users = new List<User>();
            for (var i = 0; i < 2; i++)
            {
                var user = new User
                {
                    Username = "user" + i,
                    Password = "pass" + i
                };

                users.Add(user);
            }

            var rUsers = _repository.Save<User>(users).ToList();

            foreach (var data in rUsers)
            {
                var user = data;
                user.Address = "Address " + user.Username;
            }

            rUsers = _repository.Save<User>(rUsers).ToList();

            Assert.NotNull(rUsers);
            Assert.NotEmpty(rUsers);
            Assert.Equal(users.Count, rUsers.Count);
            Assert.Equal(users, rUsers);
        }

        [Fact]
        public void DeleteT()
        {
            var user = new User
            {
                Username = "user3",
                Password = "user3"
            };

            user = _repository.Save(user);
            Assert.NotNull(user);

            var id = user.Id;
            _repository.Delete(user);

            Assert.Throws(typeof(KeyMissingException), () =>
            {
                var rUser = _repository.GetById<User>(id);
                Assert.Null(rUser);
            });
        }
        
        [Fact]
        public void Delete()
        {
            var user = new User
            {
                Username = "user3a",
                Password = "user3a"
            };

            user = _repository.Save(user);
            Assert.NotNull(user);

            var id = user.Id;
            _repository.Delete(id);

            Assert.Throws(typeof(KeyMissingException), () =>
            {
                var rUser = _repository.GetById(id);
                Assert.Null(rUser);
            });
        }

        [Fact]
        public void Find1()
        {
            var user = new User
            {
                Username = "user4",
                Password = "user4"
            };

            _repository.Save(user);

            var users = _repository.Find<User>().Where(x => x.Username.Contains("user")).ToList();
            Assert.NotEmpty(users);

            var users1 = _repository.Find().Where(x => ((User)x).Username.Contains("user")).ToList();
            Assert.NotEmpty(users1);

            var bUser = _repository.FindOne(x => x.Id == users.FirstOrDefault()?.Id);

            Assert.NotNull(bUser);
        }

        [Fact]
        public void Find2()
        {
            var user = new User
            {
                Username = "user5",
                Password = "user5"
            };

            _repository.Save(user);

            var users = _repository.Find<User>(x => x.Username.Contains("user")).ToList();
            Assert.NotEmpty(users);

            var users1 = _repository.Find(x => ((User) x).Username.Contains("user")).ToList();
            Assert.NotEmpty(users1);

            var bUser = _repository.FindOne(x => x.Id == users.FirstOrDefault()?.Id);
            Assert.NotNull(bUser);
        }

        [Fact]
        public void FindOne()
        {
            var user = new User
            {
                Username = "user7",
                Password = "user7"
            };

            _repository.Save(user);

            var aUser = _repository.FindOne<User>(x => x.Username.Contains("user"));

            Assert.NotNull(aUser);


            var bUser = _repository.FindOne(x => x.Id == aUser.Id);

            Assert.NotNull(bUser);
        }

        [Fact]
        public void GetById1()
        {
            var user = new User
            {
                Username = "user6",
                Password = "user6"
            };

            user = _repository.Save(user);

            var id = user.Id;

            var rUser = _repository.GetById<User>(id);
            var rUser1 = _repository.GetById(id);
            var rUser2 = _repository.GetById((DataReference) id);

            Assert.NotNull(rUser);
            Assert.NotNull(rUser1);
            Assert.NotNull(rUser2);
            Assert.Equal(user, rUser);

            Assert.IsType<User>(rUser1);
            Assert.IsType<User>(rUser2);
        }

        [Fact]
        public void GetById2()
        {
            Assert.Throws<ArgumentMissingException>(() =>
            {
                _repository.GetById<User>((DataReference) null);
            });

            Assert.Throws<ArgumentMissingException>(() =>
            {
                _repository.GetById<User>((DataReference) "");
            });
        }

        [Fact]
        public void ValidateId()
        {
            var user = new User
            {
                Username = "user7",
                Password = "user7"
            };

            user = _repository.Save(user);

            var id = user.Id;
            var id2 = _repository.ValidateId<User>((DataReference) id);

            Assert.NotNull(id2);

            Assert.Throws<ArgumentMissingException>(() =>
            {
                _repository.ValidateId<User>("");
            });
            Assert.Throws<KeyMissingException>(() =>
            {
                _repository.ValidateId<User>(DataReference.NewIdentity());
            });
        }
    }
}
