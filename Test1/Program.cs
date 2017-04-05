using System;
using Bit0.Utils.Common.Data;
using Newtonsoft.Json;

namespace Test1
{
    internal class User
    {
        public DataReference Id { get; set; }
        public DataReference CustId { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var id = DataReference.NewIdentity();

            var u = new User
            {
                Id = DataReference.NewIdentity(),
                CustId = id
            };


            var a = JsonConvert.SerializeObject(u);
            var b = JsonConvert.DeserializeObject<User>(a);
        }
    }
}