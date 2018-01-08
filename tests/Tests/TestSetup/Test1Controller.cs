using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.Tests.Data.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Bit0.Utils.JSend.Http;

namespace Bit0.Utils.Tests.TestSetup
{
    public class Test1Controller : ControllerBase, IJSendController
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

        [HttpGet]
        public User Action2()
        {
            throw new InvalidCredentialsException(new { message = "Error" });
        }

        [HttpGet]
        public User Action3()
        {
            throw new NullObjectException("test");
        }

        [HttpGet]
        public User Action4()
        {
            throw new ArgumentException("missing test");
        }

        [HttpGet]
        public async Task<User> Action5()
        {
            await Response.WriteAsync("Test");

            throw new Exception("response started");
        }

        [HttpGet]
        public async Task<User> Action6()
        {
            await Response.WriteAsync("Test");

            throw new Exception("response started");
        }

        public Type DataType { get; }
    }
}