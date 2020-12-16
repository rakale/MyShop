using Abc.Data.Shop;
using Abc.Domain.Common;

namespace Abc.Domain.Shop {
    public sealed class Basket: UniqueEntity<BasketData> {
        public Basket(BasketData d) : base(d) { }
        public string BuyerId => Data?.BuyerId ?? Unspecified;
    }


}
