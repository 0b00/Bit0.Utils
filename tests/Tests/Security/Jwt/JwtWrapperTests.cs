using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;
using Jose;
using Xunit;

namespace Bit0.Utils.Tests.Security.Jwt
{
    public class JwtWrapperTests
    {
        public class Jwt1 : JsonWebToken
        {
            public override IDictionary<String, Object> Claims => ClaimsList;

            public Jwt1(Int32 expiresInSeconds = 1800, Int32 notBeforeSeconds = 0) : base(expiresInSeconds, notBeforeSeconds)
            { }
        }

        private readonly IJwtKey _jwtKey;

        public JwtWrapperTests()
        {
            _jwtKey = new JwtKeyHMAC("test");
        }

        [Theory]
        [InlineData(200)]
        [InlineData(0)]
        [InlineData(-200)]
        public void NotBeforeTests(Int32 notBeforeSeconds)
        {
            var payload = new Jwt1(notBeforeSeconds: notBeforeSeconds).Claims;
            var jwt = JwtWrapper.Generate(payload, _jwtKey);

            JwtWrapper.Parse(jwt, _jwtKey);
        }

        [Fact]
        public void InValidKey()
        {

            var payload = new Jwt1().Claims;
            var key = new JwtKeyHMAC(Encoding.UTF8.GetBytes("test1"), JwsAlgorithm.ES512);
            var jwt = JwtWrapper.Generate(payload, _jwtKey);

            Assert.Throws<IntegrityException>(() =>
            {
                JwtWrapper.Parse(jwt, key);
            });
        }

        [Fact]
        public void PayLoadTest()
        {
            var payload = new Jwt1().Claims;
            var jwt = JwtWrapper.Generate(payload, _jwtKey);

            var claims = JwtWrapper.Payload(jwt);

            Assert.Equal("unknown", claims[JwtClaimKeys.Issuer]);
            Assert.Equal("unknown", claims[JwtClaimKeys.Audience]);
        }
    }
}
