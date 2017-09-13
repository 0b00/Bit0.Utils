using System;
using Bit0.Utils.JSend.Responses;
using Xunit;

namespace Tests
{
    public class JSendTests
    {
        [Fact]
        public void ErrorResponse()
        {
            const String str = "Error message";
            const Int32 status = 500;
            const Int32 innerStatus = 400;
            var ex = new ArgumentNullException();

            var error1 = new ErrorResponse(str, status, innerStatus);
            var error2 = new ErrorResponse(str, status, innerStatus, ex);
            var error3 = new ErrorResponse(str, innerStatus, ex);
            var error4 = new ErrorResponse(str, ex);

            Assert.Equal(str, error1.Message);
            Assert.Equal(status, error1.StatusCode.Code);
            Assert.Equal(innerStatus, error1.StatusCode.InternalCode);
            Assert.Null(error1.Exception);
            Assert.Equal("error", error1.StringStatus);

            Assert.Equal(str, error2.Message);
            Assert.Equal(status, error2.StatusCode.Code);
            Assert.Equal(innerStatus, error2.StatusCode.InternalCode);
            Assert.IsType(typeof(ArgumentNullException), error2.Exception);
            Assert.Null(error2.StackTrace);

            Assert.Equal(str, error3.Message);
            Assert.Equal(500, error3.StatusCode.Code);
            Assert.Equal(innerStatus, error3.StatusCode.InternalCode);
            Assert.IsType(typeof(ArgumentNullException), error3.Exception);

            Assert.Equal(str, error4.Message);
            Assert.Equal(500, error4.StatusCode.Code);
            Assert.Equal(500, error4.StatusCode.InternalCode);
            Assert.IsType(typeof(ArgumentNullException), error4.Exception);
        }

        [Fact]
        public void SuccessResponse()
        {
            var data = new Data
            {
                Prop1 = "a",
                Prop2 = 1
            };

            const Int32 status = 200;
            const Int32 innerStatus = 5201;

            var success1 = new SuccessResponse(data);
            var success2 = new SuccessResponse(data, status, innerStatus);
            var success3 = new SuccessResponse<Data>(data);
            var success4 = new SuccessResponse<Data>(data, status, innerStatus);

            Assert.IsType<Data>(success1.Data);
            Assert.Equal(data, success1.Data);
            Assert.Equal(200, success1.StatusCode.Code);
            Assert.Equal(200, success1.StatusCode.InternalCode);

            Assert.IsType<Data>(success2.Data);
            Assert.Equal(data, success2.Data);
            Assert.Equal(status, success2.StatusCode.Code);
            Assert.Equal(innerStatus, success2.StatusCode.InternalCode);

            Assert.IsType<Data>(success3.Data);
            Assert.Equal(data, success3.Data);
            Assert.Equal(data.Prop1, success3.Data.Prop1);
            Assert.Equal(data.Prop2, success3.Data.Prop2);
            Assert.Equal(200, success3.StatusCode.Code);
            Assert.Equal(200, success3.StatusCode.InternalCode);
            
            Assert.IsType<Data>(success4.Data);
            Assert.Equal(data, success4.Data);
            Assert.Equal(status, success4.StatusCode.Code);
            Assert.Equal(innerStatus, success4.StatusCode.InternalCode);
        }

        [Fact]
        public void FailResponse()
        {
            var data = new Data
            {
                Prop1 = "a",
                Prop2 = 1
            };
            
            const Int32 status = 400;
            const Int32 innerStatus = 5401;

            var fail1 = new FailResponse(data);
            var fail2 = new FailResponse(data, status, innerStatus);
            var fail3 = new FailResponse<Data>(data);
            var fail4 = new FailResponse<Data>(data, status, innerStatus);

            Assert.IsType<Data>(fail1.Data);
            Assert.Equal(data, fail1.Data);
            Assert.Equal(400, fail1.StatusCode.Code);
            Assert.Equal(400, fail1.StatusCode.InternalCode);

            Assert.IsType<Data>(fail2.Data);
            Assert.Equal(data, fail2.Data);
            Assert.Equal(status, fail2.StatusCode.Code);
            Assert.Equal(innerStatus, fail2.StatusCode.InternalCode);

            Assert.IsType<Data>(fail3.Data);
            Assert.Equal(data, fail3.Data);
            Assert.Equal(data.Prop1, fail3.Data.Prop1);
            Assert.Equal(data.Prop2, fail3.Data.Prop2);
            Assert.Equal(400, fail3.StatusCode.Code);
            Assert.Equal(400, fail3.StatusCode.InternalCode);
            
            Assert.IsType<Data>(fail4.Data);
            Assert.Equal(data, fail4.Data);
            Assert.Equal(status, fail4.StatusCode.Code);
            Assert.Equal(innerStatus, fail4.StatusCode.InternalCode);
        }
    }

    public class Data
    {
        public String Prop1 { get; set; }
        public Int32 Prop2 { get; set; }
    }
}
