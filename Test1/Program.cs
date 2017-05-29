using System;
using Bit0.Utils.Common;
using Bit0.Utils.Common.Extensions;
using Bit0.Utils.Data.Reference;
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
            //var id = DataReference.NewIdentity();

            //var u = new User
            //{
            //    Id = DataReference.NewIdentity(),
            //    CustId = id
            //};


            //var a = JsonConvert.SerializeObject(u);
            //var b = JsonConvert.DeserializeObject<User>(a);

            //var t = new T1
            //{
            //    Measurement = new Measurement(MeasurementUnit.Boxes, 2),
            //    Money = new Money { Amount = 10, AmountHasVat = true, Currency = Currency.SEK, Vat = 2 }
            //};

            //var c = JsonConvert.SerializeObject(t);

            Console.WriteLine(((double)1493301552).ToUtc().ToLocalTime().ToString("o"));
        }
    }

    public class T1
    {
        public Measurement Measurement { get; set; }
        public Money Money { get; set; }
    }
}