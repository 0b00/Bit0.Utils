using System;
using Bit0.Utils.Data.Providers;
using System.IO;
using Xunit;

namespace Bit0.Utils.Tests.Data.Providers
{
    public class SimpleDataProviderTests
    {

        [Fact]
        public void SaveAndLoad()
        {
            try
            {
                var file = new FileInfo($"{nameof(SimpleDataProviderTests)}.Data.json").FullName;

                var fileInfo = new FileInfo(file);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }

                IDataProvider dataProvider = new SimpleDataProvider(1, file);

                var user = new User
                {
                    Username = "user1"
                };

                var id = dataProvider.Add(user);

                dataProvider.SaveChanges(true);
                ((SimpleDataProvider) dataProvider).SaveChangesAsync().GetAwaiter().GetResult();

                dataProvider = new SimpleDataProvider(1, file);

                var user1 = dataProvider.Entry<User>(id.Id);

                Assert.Equal(id, user1.Id);
                Assert.Equal(user.Username, user1.Username);
                Assert.NotEmpty(dataProvider.Set<User>());
            }
            catch (IOException)
            {
                //
            }
        }
    }
}
