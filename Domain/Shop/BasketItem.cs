using Abc.Data.Shop;
using Abc.Domain.Common;

namespace Abc.Domain.Shop {
    public sealed class BasketItem : ItemProduct<BasketItemData> {
        public BasketItem(BasketItemData d) : base(d) { }
        public int Quantity => Data?.Quantity ?? UnspecifiedInteger;
        public string BasketId => Data?.BasketId ?? Unspecified;
    }


}
