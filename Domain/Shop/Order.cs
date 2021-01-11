using Abc.Data.Shop;
using Abc.Domain.Common;
using System;

namespace Abc.Domain.Shop {
    public sealed class Order : UniqueEntity<OrderData> {
        public Order(OrderData d) : base(d) { }

        public string BuyerId => Data?.BuyerId ?? Unspecified;
        //TODO public DateTime OrderDate => Data?.OrderDate ?? UnspecifiedValidTo;
        public string Street => Data?.Street ?? Unspecified;
        public string City => Data?.City ?? Unspecified;
        public string State => Data?.State ?? Unspecified;
        public string Country => Data?.Country ?? Unspecified;
        public string ZipCode => Data?.ZipCode ?? Unspecified;
    }


}
