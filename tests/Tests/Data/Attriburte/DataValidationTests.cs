using Bit0.Utils.Data.Http.Attributes;
using Bit0.Utils.Tests.TestSetup;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Text;
using Bit0.Utils.Data;
using Bit0.Utils.Data.Repositories;
using Xunit;

namespace Bit0.Utils.Tests.Data.Attriburte
{
    public class DataValidationTests : ControllerTestBase<Startup2>
    {
        private readonly HttpClient _client;
        private readonly TestServer _server;

        public DataValidationTests()
        {
            _server = GetServer();
            _client = GetClient();
        }

        [Theory]
        [InlineData(null, HttpStatusCode.OK)]
        [InlineData("43b5709c-0603-45f3-bbb0-149e999576d0", HttpStatusCode.OK)]
        public void Test1(String id, HttpStatusCode expected)
        {
            var res = _client.PostAsync("/test3/data", new StringContent(JsonConvert.SerializeObject(new Test3Controller.DataModel
            {
                Id = id
            }), Encoding.Unicode, "text/json")).Result;

            Assert.Equal(expected, res.StatusCode);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("43b5709c-0603-45f3-bbb0-149e999576d0", true)]
        public void Test2(String id, Boolean expected)
        {
            var services = _server.Host.Services;
            var repository = services.GetService(typeof(IDataRepository<IData>)) as IDataRepository<IData>;

            repository?.Save(new Test3Controller.DataModel{ Id = id });

            var context = new ValidationContext(id ?? "", services, null);
            var dataValidation = new DataValidationTest();

            var res = dataValidation.IsValidTest(id, context);

            Assert.Equal(expected, res == ValidationResult.Success);
        }

        public class DataValidationTest : DataValidation
        {
            public ValidationResult IsValidTest(object model, ValidationContext validationContext)
            {
                return IsValid(model, validationContext);
            }
        }
    }
}
