using System;
using System.Collections.Generic;
using System.Text;
using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.Common.Extensions;
using Bit0.Utils.Security.Jwt;
using Xunit;

namespace Bit0.Utils.Tests.Security.Jwt
{
    public class JsonWebTokenTests
    {
        public class JwtTest : JsonWebToken
        {
            public override IDictionary<String, Object> Claims => ClaimsList;

            public JwtTest() : base(expiresInSeconds: 1800, notBeforeSeconds: 20)
            { }

            public JwtTest(String issuer, String audience) : base(issuer, audience, expiresInSeconds: 1800, notBeforeSeconds: 20)
            { }

            public JwtTest(IDictionary<String, Object> claims) : base(claims)
            { }
        }

        [Fact]
        public void Test1()
        {
            var jwt = new JwtTest();
            var date = DateTime.Now;

            Assert.Equal("unknown", jwt.Issuer);
            Assert.Equal("unknown", jwt.Audience);
            Assert.Equal(date.AddSeconds(1800).ToUnixEpoch(), jwt.Expiry);
            Assert.Equal(date.ToUnixEpoch(), jwt.IssuedAt);
            Assert.Equal(date.AddSeconds(20).ToUnixEpoch(), jwt.NotBefore);
        }

        [Fact]
        public void Test2()
        {
            var jwt = new JwtTest("issuer", "audience");
            var date = DateTime.Now;

            Assert.Equal("issuer", jwt.Issuer);
            Assert.Equal("audience", jwt.Audience);
        }

        [Fact]
        public void Test3()
        {
            var date = DateTime.Now;
            var claims = new Dictionary<String, Object>
            {
                { JwtClaimKeys.Issuer, "issuer" },
                { JwtClaimKeys.Audience, "audience" },
                { JwtClaimKeys.IssuedAt, date.AddSeconds(1800).ToUnixEpoch() },
                { JwtClaimKeys.Expiry, date.ToUnixEpoch() },
                { JwtClaimKeys.NotBefore, date.AddSeconds(20).ToUnixEpoch() },
            };

            var jwt = new JwtTest(claims);

            Assert.Equal(claims[JwtClaimKeys.Issuer], jwt.Issuer);
            Assert.Equal(claims[JwtClaimKeys.Audience], jwt.Audience);
            Assert.Equal(claims[JwtClaimKeys.IssuedAt], jwt.IssuedAt);
            Assert.Equal(claims[JwtClaimKeys.Expiry], jwt.Expiry);
            Assert.Equal(claims[JwtClaimKeys.NotBefore], jwt.NotBefore);
        }

        [Fact]
        public void Test4()
        {

            var date = DateTime.Now;
            var claims = new Dictionary<String, Object>
            {
                { JwtClaimKeys.Audience, "audience" },
                { JwtClaimKeys.IssuedAt, date.AddSeconds(-20).ToUnixEpoch() },
                { JwtClaimKeys.Expiry, date.AddSeconds(-20).ToUnixEpoch() },
                { JwtClaimKeys.NotBefore, date.AddSeconds(20).ToUnixEpoch() },
            };

            Assert.Throws<InvalidCredentialsException>(() =>
            {
                claims.ValidateDate(JwtClaimKeys.Audience, "{0}");
            });

            claims.ValidateDate(JwtClaimKeys.IssuedAt, "{0}");

            Assert.Throws<InvalidCredentialsException>(() =>
            {
                claims.ValidateDate(JwtClaimKeys.Expiry, "{0}");
            });

            Assert.Throws<InvalidCredentialsException>(() =>
            {
                claims.ValidateDate(JwtClaimKeys.NotBefore, "{0}");
            });
        }
    }
}
