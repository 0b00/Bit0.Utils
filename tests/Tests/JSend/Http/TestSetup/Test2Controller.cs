using Bit0.Utils.Tests.Data.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Bit0.Utils.Tests.JSend.Http.TestSetup
{
    public class Test2Controller : ControllerBase
    {
        [HttpGet]
        public User Action1()
        {
            return new User
            {
                Username = "user1",
                Password = "user1"
            };
        }
    }
}