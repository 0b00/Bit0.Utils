using System;
using System.Collections.Generic;
using System.Text;
using Bit0.Utils.Data;

namespace Bit0.Utils.Tests.Data.Providers
{
    public class User : IData
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
