using System;
using System.Collections.Generic;
using System.Text;
using Bit0.Utils.Data;

namespace Bit0.Utils.Tests.Data.Providers
{
    public class User : IData
    {
        public String Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public String Username { get; set; }
        public String Password { get; set; }
    }
}
