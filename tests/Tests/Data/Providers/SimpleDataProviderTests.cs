using System;
using Bit0.Utils.Data.Providers;
using System.IO;
using System.Linq;
using Xunit;

namespace Bit0.Utils.Tests.Data.Providers
{
    public class SimpleDataProviderTests
    {
        private readonly String _id = "DF8CC500-9E66-4F27-9417-95E97D23C524";

        [Fact]
        public void SaveAndLoad()
        {
            try
            {
                var file = new FileInfo($"{nameof(SimpleDataProviderTests)}.{Guid.NewGuid()}.Data.json").FullName;
                var file1 = new FileInfo($"{nameof(SimpleDataProviderTests)}.LoadingTest.Data.json").FullName;

                var fileInfo = new FileInfo(file1);
                if (!fileInfo.Exists)
                {
                    CreateLoadFile(fileInfo);
                }

                IDataProvider dataProvider = new SimpleDataProvider(20, file);

                var user = new User
                {
                    Username = "user1"
                };

                var id = dataProvider.Add(user);

                dataProvider.SaveChanges();
                ((SimpleDataProvider) dataProvider).SaveChangesAsync().GetAwaiter().GetResult();

                dataProvider = new SimpleDataProvider(0, fileInfo.FullName);

                var user1 = dataProvider.List<User>(x => x.Password.Equals("user1")).FirstOrDefault() ?? new User();

                Assert.Equal(_id, user1.Id);
                Assert.Equal(user.Username, user1.Username);
                Assert.NotEmpty(dataProvider.Set<User>());
            }
            catch (IOException)
            {
                //
            }
        }

        private void CreateLoadFile(FileInfo fileInfo)
        {
            IDataProvider dataProvider = new SimpleDataProvider(20, fileInfo.FullName);

            var user = new User
            {
                Id = _id,
                Username = "user1",
                Password = "user1"
            };

            var id = dataProvider.Add(user);

            dataProvider.SaveChanges(true);
        }
    }
}
