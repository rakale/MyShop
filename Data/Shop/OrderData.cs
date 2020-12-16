using Abc.Data.Common;
using System;

namespace Abc.Data.Shop {
    public class OrderData : UniqueEntityData {
        public string BuyerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }

}
