using Bit0.Utils.Generators;
using Xunit;

namespace Bit0.Utils.Tests.Generators
{
    public class PasswordTests
    {
        [Fact]
        public void Generate()
        {
            var password = Password.Generate(15);

            Assert.Equal(15, password.Length);
        }
    }
}
