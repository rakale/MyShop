using Abc.Data.Shop;
using Abc.Domain.Common;

namespace Abc.Domain.Shop {
    public sealed class Buyer : NamedEntity<BuyerData> {
        public Buyer(BuyerData d) : base(d) { }
        public string Street => Data?.Street ?? Unspecified;
        public string City => Data?.City ?? Unspecified;
        public string State => Data?.State ?? Unspecified;
        public string Country => Data?.Country ?? Unspecified;
        public string ZipCode => Data?.ZipCode ?? Unspecified;
    }
}
